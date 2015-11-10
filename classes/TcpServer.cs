using System;
using System.Net;
using System.Xml.Serialization;
using System.Net.Sockets;
using System.Threading;

namespace Mountain.classes {

    public class TcpServer {
        [XmlIgnore]
        public int Connections { get; private set; }
        protected AutoResetEvent connectionWaitDone;
        public TcpListener tcpListener;
        public int Port;
        [XmlIgnore]
        World world;
        [XmlIgnore]
        ApplicationSettings settings;

        public TcpServer(World world, ApplicationSettings appSettings) {
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
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, tcpListener);
        }

        protected void HandleAsyncConnection(IAsyncResult result) {
            TcpListener listener = (TcpListener)result.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(result);
            connectionWaitDone.Set();
            tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, listener);
            Connection player = new Connection(client, settings);
            player.StartLogin();
         //   this.settings.Logins.Add(new Login(client, settings));
        }

        public void StopServer() {
            if (tcpListener != null) {
                tcpListener.Stop();
                tcpListener = null;
            }
        }

    }
}
