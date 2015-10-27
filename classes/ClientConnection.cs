using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class ClientConnection : Identity {
        public TcpClient ClientSocket { get; set; }
        protected TcpClient socket;
        private const int BufferSize = 8 * 1024;
        protected NetworkStream stream;
        protected StreamWriter writer;
        protected StreamReader reader;

        public ClientConnection(TcpClient tcpClientSocket) {
            base.ClassType = classType.client;
            this.ClientSocket = tcpClientSocket;
            byte[] buffer = new byte[BufferSize];
            this.stream = tcpClientSocket.GetStream();
            try {
                ClientSocket.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnReceive, buffer);
            } catch {
                DropConnection();
            }
        }

        private void DropConnection() {
            // log event
        }

        public void OnReceive(IAsyncResult ar) {
            while (true) {
                string inputLine = "";
                while (inputLine != null) {
                    writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
                    reader = new StreamReader(stream, Encoding.ASCII);

                    inputLine = reader.ReadLine();
                    writer.WriteLine("Echoing string: " + inputLine);
                    Console.WriteLine("Echoing string: " + inputLine);
                }
                Console.WriteLine("Server saw disconnect from client.");
            }
        }        

    }
}
