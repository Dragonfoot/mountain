using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;

namespace Mountain.classes.handlers {

    public class RoomCommands {

        private Dictionary<string, Action<Packet>> List;
        ApplicationSettings settings;
        public List<string> Keys;

        public RoomCommands(ApplicationSettings appSettings) {
            settings = appSettings;
            LoadRoomCommands();
        }
        private void LoadRoomCommands() {
            List = new Dictionary<string, Action<Packet>>(){
                {"say", Say},
                {"tell", Tell},
                {"yell", Yell},
                {"shout", Shout},
                {"talk", Talk},
                {"whisper", Whisper},
                {"look", Look },

            };
            Keys = new List<string>(List.Keys);
        }

        public bool IsVerb(string verb) {
            return Keys.Any(key => key.StartsWith(verb));
        }

        public string ShowCommands(int size) {
            string helplist = string.Join(", ", Keys.ToArray());
            return helplist.WordWrap(size);
        }

        public bool InvokeCommand(string verb, Packet packet) {
            if (List.ContainsKey(verb)) {
                List[verb](packet);
                return true;
            }
            return false;
        }

        private void Say(Packet packet) {
            try {
                if (packet.parameter.IsNullOrWhiteSpace()) {
                    packet.Client.Send("Say what?".Color(Ansi.yellow, Ansi.white).NewLine(), true);
                    return;
                }
                if (!packet.parameter.HasLastCharPunctuation()) { packet.parameter += "."; }
                string message = "\"" + packet.parameter + "\"".NewLine().Color(Ansi.white);
                foreach (Connection player in packet.Client.Room.Players) {
                    if (player.Account.Name == packet.Client.Account.Name) {
                        player.Send("You say, ".Color(Ansi.white) + message.Color(Ansi.white), true);
                    } else {
                        player.Send(packet.Client.Account.Name + " says, ".Color(Ansi.white) + message.Color(Ansi.white), true);
                    }
                }
            } catch (Exception e) {
                settings.SystemMessageQueue.Push(e.ToString());
            }
        }

        private void Look(Packet packet) {
            string response = packet.Client.Room.GetName(), names = string.Empty;
            packet.Client.Send("".NewLine(), false);
            packet.Client.Send(response.Color(Ansi.cyan).NewLine().NewLine(), true);
            response = packet.Client.Room.GetDesciption();
            packet.Client.Send(response.Color(Ansi.white).WordWrap(), false);
            names = Extensions.GetNames(packet.Client.Room.Exits.ToArray());
            if (names != string.Empty) response = "Obvious Exits: " + names;
             else response = "Obvious Exits: ";
            packet.Client.Send(response.Color(Ansi.green).NewLine(), true);
            names = string.Empty;
            int count = packet.Client.Room.Players.Count, i = 0;
            foreach (Connection player in packet.Client.Room.Players) {
                if (player.Account.Name != packet.Client.Account.Name) {
                    names = names + packet.Client.Account.Name;
                    if (i != count) { names = names + ", "; }
                    if (i == count) { names = names + "."; }
                    i++;
                }
                if (names != string.Empty)
                    packet.Client.Send(names.Color(Ansi.cyan).WordWrap().NewLine(), true);
                names = Extensions.GetNames(packet.Client.Room.Mobs.ToArray());
                if(names != string.Empty) packet.Client.Send(names.Color(Ansi.green).NewLine(), true);
                // add items
            }
        }

        private void Shout(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) +
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine(), true);
        }

        private void Tell(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) +
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine(), true);
        }

        private void Yell(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) +
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine(), true);
        }

        private void Talk(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) +
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine(), true);
        }

        private void Whisper(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) + 
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine(), true);
        }
    }
}

