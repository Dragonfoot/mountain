using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class ClientConnection : Identity {
        private StateObject state { get; set; }
        public TcpClient ClientSocket {get;set;}
        private readonly ManualResetEvent MessageReceivedDone;
        private readonly ManualResetEvent MessageSentDone;
        protected MessageQueue messageQueue;  // derived ConcurrentQueue with added event - "new message available"

        public ClientConnection(TcpClient tcpClientSocket) {
            ClassType = classType.client;
            ClientSocket = tcpClientSocket;
            MessageReceivedDone = new ManualResetEvent(false);
            MessageSentDone = new ManualResetEvent(false);
            messageQueue = new MessageQueue();
            state = new StateObject((tcpClientSocket));
            StartReceiving();
        }

        protected void StartReceiving() {
            try {
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallback, state);
            } catch {
                DropConnection("client closed by user or socket error");
            }
        }
        public void ReceiveCallback(IAsyncResult ar) {
            try {

                int read = state.Socket.Client.EndReceive(ar); // get number of bytes read in
                if (read > 0) {
                    string incomingMessage = Encoding.ASCII.GetString(state.Buffer, 0, read).StripNewLine();
                    messageQueue.Push(incomingMessage); // put the received message into queue for processing by derived class                
                    MessageReceivedDone.Set(); // tell calling thread we are done with this message
                }
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, ReceiveCallback, state); // continue to wait for more

            } catch (ObjectDisposedException) {
                // Handle the socket being closed with an async receive pending
            } catch (Exception e) {
                // Handle all other exceptions
            }
        }

        protected void Send(string data, bool indent) {
            if (indent) { data = data.Indent(Global.indent); }
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            state.Socket.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, state);
        }

        private void SendCallback(IAsyncResult ar) { // delegate that runs once the send thread has finished
            try {
                int bytesSent = state.Socket.Client.EndSend(ar);
                MessageSentDone.Set(); // tell parent thread we are good to go
            } catch (Exception e) {
              //  add error message to world concurrentQueue
            }
        }        
       
        private void DropConnection(string action) { // connection has died, been requested by world or an error occurred 
            // logErrorEvent(this.ID + " : " + action);
        }
    }
    
    public class StateObject {  // data that's passed between threads using delegates
        private const int BUFFER_SIZE = 1024;
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public TcpClient Socket { get; set; }
        public StateObject(TcpClient workSocket) {
            Socket = workSocket;
        }
    }
}
