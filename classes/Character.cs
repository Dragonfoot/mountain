using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using Mountain.classes.Interfaces;

namespace Mountain.classes {

    abstract class Character : BaseObject {
        protected Socket socket;
    }
}
