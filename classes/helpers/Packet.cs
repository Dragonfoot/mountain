using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public enum packetType { message, data, command, activity, callback };

    public class Packet {
        protected packetType type;
        public Packet() {
        }
        public Packet(object value) {
        }
    }

}
