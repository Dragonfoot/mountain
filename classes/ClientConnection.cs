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
        private readonly object messageLock;
        protected MessageQueue messageQueue;  // derived ConcurrentQueue with additional event trigger

        public ClientConnection(TcpClient tcpClientSocket) {
            ClassType = classType.client;
            ClientSocket = tcpClientSocket;
            messageLock = new object();
            MessageReceivedDone = new ManualResetEvent(false);
            MessageSentDone = new ManualResetEvent(false);
            messageQueue = new MessageQueue();
            messageQueue.OnMessageReceived += base_OnMessageReceived;
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
                    string msg = Encoding.ASCII.GetString(state.Buffer, 0, read).StripNewLine();
                    lock (messageLock) { // stop other threads from accessing the messageQueue while this message is added
                        messageQueue.Push(msg); // put the received message into the threaded queue for processing by another thread
                    }
                    MessageReceivedDone.Set(); // tell parent thread we are done
                }
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, ReceiveCallback, state); // loop to wait for more
            } catch (ObjectDisposedException) {
                // Handle the socket being closed with an async receive pending
            } catch (Exception e) {
                // Handle all other exceptions
            }
        }


        protected void Send(string data) {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            state.Socket.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, state);
        }
        protected void SendIndented(String data) { // duplicate of above but for the additional tab at start of line
            byte[] byteData = Encoding.ASCII.GetBytes(data.Indent(Global.indent));
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
        
        protected void base_OnMessageReceived(object myObject) { // derived classes will implement this event
        }
        private void DropConnection(string action) { // connection has died, been requested by world or an error occurred 
            // log event
        }
    }
    
    public class StateObject {  // passed between threads and delegates
        private const int BUFFER_SIZE = 1024;
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public TcpClient Socket { get; set; }
        public StateObject(TcpClient workSocket) {
            Socket = workSocket;
        }
    }
}
