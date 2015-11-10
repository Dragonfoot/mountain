
namespace Mountain.classes.helpers {

    public enum PacketType { data, command, activity, callback, verb };

    public class Packet {
        public PacketType packetType;
        public Packet() {
            packetType = PacketType.data;
        }
    }
    public class VerbPacket : Packet {
        public string verb;
        public string parameter;
        public Connection Client;
        public VerbPacket(string verb, string parameter, Connection client) {
            packetType = PacketType.verb;
            this.verb = verb;
            this.parameter = parameter;
            Client = client;
        }
    }
    public class PlayerEventPacket : Packet {
        public string verb;
        public string parameter;
        public Connection Client;
        public PlayerEventPacket(string verb, string parameter, Connection client) {
            packetType = PacketType.activity;
            this.verb = verb;
            this.parameter = parameter;
            Client = client;
        }
    }
    public class GeneralEventPacket : Packet {

    }

}
