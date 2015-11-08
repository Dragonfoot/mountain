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
        public Player player;
        public VerbPacket(string verb, string parameter, Player player) {
            packetType = PacketType.verb;
            this.verb = verb;
            this.parameter = parameter;
            this.player = player;
        }
    }
    public class PlayerEventPacket : Packet {
        public string verb;
        public string parameter;
        public Player player;
        public PlayerEventPacket(string verb, string parameter, Player player) {
            packetType = PacketType.events;
            this.verb = verb;
            this.parameter = parameter;
            this.player = player;
        }
    }
    public class GeneralEventPacket : Packet {

    }

}
