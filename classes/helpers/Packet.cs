using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {
    public enum packetType { message, data, command, activity, callback }; 

    public class Packet {
        protected packetType type;
        public Packet(Identity sender, packetType t, DataPacket data) {
        }
    }

    public class DataPacket {
        // derive different packet types off of this
    }
    public class PacketMessage {
    }
    public class PacketData {
    }
    public class PacketCommand {
    }
    public class PacketActivity {
    }
    public class PacketCallback {
    }
}
