using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Mountain.classes.tcp {
    
     [Serializable] public class TcpServerListener {
        protected AutoResetEvent connectionWaitDone;
        public TcpListenerActive tcpListener;
        public int Port;
        World world;
        ApplicationSettings settings;

        public TcpServerListener(World world, ApplicationSettings appSettings) {
            this.world = world;
            connectionWaitDone = new AutoResetEvent(false);
            this.settings = appSettings;
        }

        public void StartServer(int port) {
            Port = port;
            if (tcpListener != null) {
                tcpListener.Stop();
                tcpListener = null;
            }
            tcpListener = new TcpListenerActive(IPAddress.Any, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, tcpListener);
        }

        public bool Active() {
            return tcpListener.Active;
        }

        protected void HandleAsyncConnection(IAsyncResult result) {
            TcpClient client;
            try {
                TcpListenerActive listener = (TcpListenerActive)result.AsyncState;
                client = listener.EndAcceptTcpClient(result);                
                connectionWaitDone.Set();
                tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, listener);

                Connection clientConnection = new Connection(client, settings);
                clientConnection.StartLogin();
            } catch (Exception e) {
                string msg = e.Message;
            }
        }

        public void StopServer() {
            if (tcpListener != null) {
                tcpListener.Stop();
                tcpListener = null;
            }
        }
    }
}
