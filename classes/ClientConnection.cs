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

        private FormInterface form;
        private StateObject state { get; set; }
        private readonly ManualResetEvent MessageReceived;
        private readonly ManualResetEvent MessageSent;
        private readonly object messageLock;
        protected MessageQueue messageQueue;

        public ClientConnection(TcpClient tcpClientSocket, FormInterface form) {
            ClassType = classType.client;
            this.form = form;
            messageLock = new object();
            MessageReceived = new ManualResetEvent(false);
            MessageSent = new ManualResetEvent(false);
            messageQueue = new MessageQueue();
            messageQueue.OnMessageReceived += base_OnMessageReceived;
            state = new StateObject((tcpClientSocket));
            StartReceiving();
        }


        protected void StartReceiving() {
            try {
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, ReceiveCallback, state);
            } catch {
                DropConnection();
            }
        }
        public void ReceiveCallback(IAsyncResult ar) {
            try {
                int read = state.Socket.Client.EndReceive(ar);
                if (read > 0) {
                    string msg = Encoding.ASCII.GetString(state.Buffer, 0, read).StripNewLine();
                    lock (messageLock) {
                        messageQueue.Push(msg);
                    }
                    MessageReceived.Set();
                  //  Send(msg.Color(true, Ansi.cyan, Ansi.white) + " [echo]".AddNewLine().Color(Ansi.red, Ansi.white));
                }
                state.Socket.Client.BeginReceive(state.Buffer, 0, state.Buffer.Length, 0, ReceiveCallback, state);
            } catch (ObjectDisposedException) {
                // Handle the socket being closed with an async receive pending
            } catch (Exception e) {
                //form.console.Items.Add(e.ToString());
                // Handle all other exceptions
            }
        }


        protected void Send(string data) {
            byte[] byteData = Encoding.ASCII.GetBytes(data);
            state.Socket.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, state);
        }

        protected void SendIndent(String data) {
            byte[] byteData = Encoding.ASCII.GetBytes(data.Indent(Global.indent));
            state.Socket.Client.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, SendCallback, state);
        }
        private void SendCallback(IAsyncResult ar) {
            try {
                int bytesSent = state.Socket.Client.EndSend(ar);
                MessageSent.Set();
            } catch (Exception e) {
                form.console.Items.Add(e.ToString());
            }
        }



        protected void base_OnMessageReceived(object myObject) {
        }
        private void DropConnection() {
            // log event
        }
    }


    public class StateObject {
        private const int BUFFER_SIZE = 1024;
        public byte[] Buffer = new byte[BUFFER_SIZE];
        public TcpClient Socket { get; set; }

        public StateObject(TcpClient workSocket) {
            Socket = workSocket;
        }
    }
}
