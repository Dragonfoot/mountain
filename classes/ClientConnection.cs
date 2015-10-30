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
        private readonly ManualResetEvent MessageReceived;
        private readonly ManualResetEvent MessageSent;
        private object messageLock;
        protected MessageQueue messageQueue;

        public ClientConnection(TcpClient tcpClientSocket) {
            ClassType = classType.client;
            messageLock = new object();
            MessageReceived = new ManualResetEvent(false);
            MessageSent = new ManualResetEvent(false);
            messageQueue = new MessageQueue();
            messageQueue.OnMessageReceived += messageQueue_OnMessageReceived;
            state = new StateObject((tcpClientSocket));
        }

        protected void Receive() {
            try {
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallback, state);
            } catch {
                DropConnection();
            }
        }
        public void ReceiveCallback(IAsyncResult ar) {
            try {
                //StateObject so = (StateObject)ar.AsyncState;
                int read = state.Socket.Client.EndReceive(ar);
                if (read > 0) {
                    string msg = Encoding.ASCII.GetString(state.Buffer, 0, read).StripNewLine();
                    lock (messageLock) {
                        messageQueue.Push(msg);
                    }
                    MessageReceived.Set();
                    Send(state.Socket, msg.Color(Ansi.cyan) + " [response]".AddNewLine().Color(Ansi.red));
                }
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, ReceiveCallback, state);

            } catch (ObjectDisposedException) {
                // Handle the socket being closed with an async receive pending
            } catch (Exception e) {
                // Handle all other exceptions
            }
        }

        private void Send(TcpClient client, String data) {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            client.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, client);
        }
        private void SendCallback(IAsyncResult ar) {
            try {
                int bytesSent = state.Socket.Client.EndSend(ar);
                MessageSent.Set();
            } catch (Exception e) {
              //  Console.WriteLine(e.ToString());
            }
        }



        private void messageQueue_OnMessageReceived(object myObject) {
            //throw new NotImplementedException();
        }
        private void DropConnection() {
            // log event
        }
    }

    public class StateObject {
        private const int BUFFER_SIZE = 8 * 1024;
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public readonly TcpClient Socket = null;

        public StateObject(TcpClient workSocket) {
            Socket = workSocket;
        }
    }
    public class Packet {
        public readonly byte[] Buffer;
        public readonly DateTime Timestamp;

        public Packet(DateTime timestamp, byte[] buffer, int size) {
            Timestamp = timestamp;
            Buffer = new byte[size];
            System.Buffer.BlockCopy(buffer, 0, Buffer, 0, size);
        }
    }
}
