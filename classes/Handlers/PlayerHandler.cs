using Mountain.classes.tcp;
using Mountain.classes.dataobjects;

namespace Mountain.classes.handlers {

    public class PlayerHandler {
        Connection Client;
        ApplicationSettings settings;
        protected Dispatch Commands { get; set; }

        public PlayerHandler(Connection client, ApplicationSettings appSettings) {
            Client = client;
            settings = appSettings;
            Commands = new Dispatch(Client, settings);
        }

        public void OnPlayerMessageReceived(object myObject, string message) {
            if (message.IsNullOrWhiteSpace()) return;
            VerbPacket packet = Parse(message, Client);
            if (packet == null) {
                string verb = message.FirstWord();
                Client.Send("I don't know what to do with \"".Color(Ansi.yellow) + verb.Color(Ansi.white) + "\" just yet.".Color(Ansi.yellow).NewLine(), true);
                if (Commands.IsCommunicationVerb(verb)) {
                    Client.Send("But, um.. I did a few minutes ago..\"scratch\"".Color(Ansi.yellow).NewLine(), true);
                }
                string str = message.TrimStart(' ');
                str = str.StripExtraSpaces();
                string command = str.FirstWord();
                string tail = str.StripFirstWord();
                string response = command + " \"" + tail.Trim() + "\"";
                Client.Send(response.Color(Ansi.cyan, Ansi.white).NewLine(), true);
                return;
            }
            Commands.InvokeCommand(packet.verb, packet);
        }

        private void SetRoom(Room room) {
            Client.Room = room;
            Client.Account.RoomID = room.RoomID;
            Client.Account.Room = room;
        }

        private VerbPacket Parse(string str, Connection player) {
            string verb, tail = string.Empty;
            str = str.TrimStart(' ');
            str = str.StripExtraSpaces();
            if (str.FirstChar() == '\'') {
                verb = "say";
                tail = str.StripFirstChar();
                tail = tail.TrimStart(' ');
            } else {
                verb = str.FirstWord();
                if (verb == "say") { tail = str.StripFirstWord(); } else { tail = str.StripFirstWord().ToLower(); }
            }
            if (Commands.IsCommunicationVerb(verb)) {
                VerbPacket packet = new VerbPacket(verb, tail, player);
                return packet;
            }
            return null;
        }
    }
}
