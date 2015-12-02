using System;
using Mountain.classes.tcp;
using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes.handlers {

    [Serializable] public class PlayerDispatcher {
        Connection Client;
        protected Dispatch Commands { get; set; }

        public PlayerDispatcher(Connection client) {
            Client = client;
            Commands = new Dispatch(Client);
        }

        public void OnPlayerMessageReceived(object myObject, string message) {
            if (message.IsNullOrWhiteSpace())
                return;
            Packet packet = Parse(message, Client);
            if (!packet.known) {
                string verb = packet.verb;
                Commands.DontKnowHow(packet);
                if (Commands.IsCommand(verb)) {
                    Client.Send("But, um.. I did a few minutes ago..\"scratch\"".Ansi(Style.yellow).NewLine());
                }
                return;
            }
            Commands.InvokeCommand(packet.verb, packet);
            packet.Client.Send(Client.Stats.HealthPrompt());
        }

        private void SetRoom(Room room) {
            Client.Location.Room = room;
            Client.Account.Location = new Linkage(room.Name, room.Location.Area, room);
        }

        private Packet Parse(string message, Connection player) {
            Packet packet = new Packet(string.Empty, string.Empty, player);
            message = message.TrimStart(' ');
            message = message.StripExtraSpaces();

            if (message.FirstChar() == '\'') {
                message = message.Remove(0, 1).Insert(0, "say ").StripExtraSpaces();
                packet.known = true;
            } else {
                if (message.FirstWordIsSingleChar()) {
                    char ch = message.FirstChar();
                    switch (ch) {
                        case 'l':
                            message = message.Remove(0, 1).Insert(0, "look");
                            packet.known = true;
                            break;
                        case 'i':
                            message = message.Remove(0, 1).Insert(0, "inventory");
                            packet.known = true;
                            break;
                        case '?':
                            message = message.Remove(0, 1).Insert(0, "help");
                            packet.known = true;
                            break;
                    }
                }
            }
            packet.verb = message.FirstWord();
            packet.parameter = message.StripFirstWord();
            if (Commands.IsCommand(packet.verb)) {
                packet.known = true;
            }
            if (!packet.known) {
                if(Functions.HasNameThatStartsWith(player.Location.Room.Exits.ToArray(), packet.verb)) {
                    packet.parameter = packet.verb;
                    packet.verb = "go";
                    packet.known = true;
                }
            }
            return packet;
        }
    }
}

