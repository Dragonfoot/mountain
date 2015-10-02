using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Mountain.classes {

    abstract public class Character : BaseObject {
        protected Socket socket;
        public Socket Socket {
            get {
                return this.socket;
            }
            set {
                this.socket = value;
            }
        }
        public Character() {
        }
        public abstract void Save();        
        public abstract void Load();

    }
}
