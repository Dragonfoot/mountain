using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public enum PacketType { data, command, action, events, callback, verb };

    public class Packet {
        public PacketType packetType;
        public Packet() {
            packetType = PacketType.data;
        }
    }
    public class VerbPacket : Packet {
        public string verb;
        public string parameter;
        public VerbPacket(string verb, string parameter) {
            packetType = PacketType.verb;
            this.parameter = parameter;
            this.verb = verb;
        }
    }
    public class EventPacket : Packet {
        public EventPacket() {
            packetType = PacketType.events;
        }
    }

}
