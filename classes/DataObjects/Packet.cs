using Mountain.classes.tcp;

namespace Mountain.classes.dataobjects {

    public enum PacketType { data, command, activity, callback, verb, system };
    public enum EventType { unknown, connect, disconnect, idle, login }
  
    public class Packet  {
        public Connection Client;
        public PacketType packetType;
        public string verb;
        public string parameter;
        public bool known;

        public Packet(string verb, string parameter, Connection client) {
            Client = client;
            packetType = PacketType.verb;
            this.verb = verb;
            this.parameter = parameter;
        }
    }

    public class SystemEventPacket {
        public Connection Client;
        public PacketType packetType;
        public EventType eventType;
        public string message;

        public SystemEventPacket(EventType eventType, string message, Connection client = null) {
            Client = client;
            packetType = PacketType.system;
            this.eventType = eventType;
            this.message = message;
        }
    }

}
