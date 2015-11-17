using Mountain.classes.tcp;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

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
            if (message.IsNullOrWhiteSpace())
                return;
            Packet packet = Parse(message, Client);
            if (!packet.known) {
                string verb = packet.verb;
                Client.Send("I don't know what to do with \"".Color(Ansi.yellow) + verb.Color(Ansi.white) + "\" just yet.".Color(Ansi.yellow).NewLine());
                if (Commands.IsCommand(verb)) {
                    Client.Send("But, um.. I did a few minutes ago..\"scratch\"".Color(Ansi.yellow).NewLine());
                }
                return;
            }
            Commands.InvokeCommand(packet.verb, packet);
        }

        private void SetRoom(Room room) {
            Client.Room = room;
            Client.Account.RoomID = room.RoomID;
            Client.Account.Room = room;
        }

        private Packet Parse(string str, Connection player) {
            Packet packet = new Packet(string.Empty, string.Empty, player);
            str = str.TrimStart(' ');
            str = str.StripExtraSpaces();
            if (str.FirstChar() == '\'') {
                str = str.Remove(0, 1).Insert(0, "say ").StripExtraSpaces();
                packet.known = true;
            } else {
                if (str.FirstWordIsSingleChar()) {
                    char ch = str.FirstChar();
                    switch (ch) {
                        case 'l':
                            str = str.Remove(0, 1).Insert(0, "look");
                            packet.known = true;
                            break;
                        case 'i':
                            str = str.Remove(0, 1).Insert(0, "inventory");
                            packet.known = true;
                            break;
                        case '?':
                            str = str.Remove(0, 1).Insert(0, "help");
                            packet.known = true;
                            break;
                    }
                }
            }
            if (!packet.known) {
                // check for room exit names, see if player wants to go/moveTo
                // if so, change verb to match moveTo
            }
            packet.verb = str.FirstWord();
            packet.parameter = str.StripFirstWord();
            if (Commands.IsCommand(packet.verb)) {
                packet.known = true;
            }
            return packet;
        }
    }
}

