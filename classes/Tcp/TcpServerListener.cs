using System;
using System.Net;
using System.Xml.Serialization;
using System.Net.Sockets;
using System.Threading;

namespace Mountain.classes.tcp {

    // listen for and accept connection requests
    public class TcpServerListener {
        [XmlIgnore]
        public int Connections { get; private set; }
        protected AutoResetEvent connectionWaitDone;
        public TcpListenerActive tcpListener;
        public int Port;
        [XmlIgnore]
        World world;
        [XmlIgnore]
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
            TcpListenerActive listener = (TcpListenerActive)result.AsyncState;
            TcpClient client = listener.EndAcceptTcpClient(result);     // new connection established 
            connectionWaitDone.Set();
            tcpListener.BeginAcceptTcpClient(HandleAsyncConnection, listener);
            Connection player = new Connection(client, settings);
            player.StartLogin();
        }

        public void StopServer() {
            if (tcpListener != null) {
                tcpListener.Stop();
                tcpListener = null;
            }
        }

    }
}
