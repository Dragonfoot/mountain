using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Login : ClientConnection {

        public Login(TcpClient socket) : base(socket) {
        }
    }
}
