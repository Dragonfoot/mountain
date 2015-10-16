using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Mountain.classes {

    abstract public class Character : Dummy {
        protected TcpClient socket; 
        private const int BufferSize = 8 * 1024;
        public TcpClient Socket {
            get {
                return this.socket;
            }
            set {
                this.socket = value;
            }
        }
        public Character(TcpClient socket) {
            this.Socket = socket;
            byte[] buffer = new byte[BufferSize];
            NetworkStream ns = socket.GetStream();
            try {
                socket.Client.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, OnReceive, buffer);
            } catch {
                DropConnection();
            }
        }

        private void DropConnection() {
        }

        public void OnReceive(IAsyncResult ar) {
            String content = String.Empty;
        }

        
        public abstract void Save();        
        public abstract void Load();

    }
}
