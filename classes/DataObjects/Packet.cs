using Mountain.classes.tcp;

namespace Mountain.classes.dataobjects {

    public enum PacketType { data, command, activity, callback, verb, system };
    public enum EventType { unknown, connection, disconnected, idle, login }
  
    public class Packet  {
        public PacketType packetType;
        public string verb;
        public string parameter;
        public bool known;
        public Connection Client;

        public Packet(string verb, string parameter, Connection client) {
            packetType = PacketType.verb;
            this.verb = verb;
            this.parameter = parameter;
            Client = client;
        }
    }

    public class SystemEventPacket {
        public PacketType packetType;
        public EventType eventType;
        public string message;
        public Connection Client;

        public SystemEventPacket(EventType eventType, string message, Connection client = null) {
            packetType = PacketType.system;
            this.eventType = eventType;
            this.message = message;
            Client = client;
        }
    }

}
