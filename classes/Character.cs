using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Mountain.classes {

    abstract class Character : BaseObject {
        protected Socket socket;
    }
}
