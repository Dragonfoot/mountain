using System.Net.Sockets;
using System.Net;

namespace Mountain.classes.tcp {

    // TcpListener wrapper to access Active state
    public class TcpListenerActive : TcpListener {

        public TcpListenerActive(IPEndPoint localEP) : base(localEP) { }
        public TcpListenerActive(IPAddress localaddr, int port) : base(localaddr, port) { }
        public new bool Active {
            get { return base.Active; }
        }
    }
}
