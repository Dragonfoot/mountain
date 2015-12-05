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
                return;
            }
            Commands.InvokeCommand(packet.verb, packet);
            packet.Client.Send(Client.Stats.HealthPrompt());
        }

        private Packet Parse(string message, Connection player) {
            Packet packet = new Packet(string.Empty, string.Empty, player);
            message = message.TrimStart(' ');
            message = message.StripExtraSpaces();

            if (message.FirstChar() == '\'') {
                message = message.Remove(0, 1).Insert(0, "say ").StripExtraSpaces();
                packet.known = true;
            } else {
                bool error = false;
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
                        default:
                            packet.parameter = packet.verb;
                            packet.verb = ch.ToString();
                            error = true;
                            break;
                    }
                }
                if (error) return packet;
            }
            packet.verb = message.FirstWord();
            packet.parameter = message.StripFirstWord();
            if (Commands.IsCommand(packet.verb)) {
                packet.known = true;
            }
            if (!packet.known) {
                string verb = packet.verb;
                packet = FUNC.ContainsExit(player.Room.Exits.ToArray(), packet);
                if (packet.verb != verb) {
                    packet.known = true;
                }                
            }
            return packet;
        }
    }
}

