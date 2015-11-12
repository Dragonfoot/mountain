using Mountain.classes.tcp;

namespace Mountain.classes.dataobjects {

    public enum PacketType { data, command, activity, callback, verb };

  
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

}
