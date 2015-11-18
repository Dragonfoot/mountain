using System;
using System.Collections.Generic;
using System.Linq;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;
using Mountain.classes.functions;

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
                {"say", Say}, {"tell", Tell}, {"yell", Yell}, {"shout", Shout}, {"talk", Talk}, {"whisper", Whisper},
                {"look", Look }, {"get", Get }, {"hide", Hide }, {"goto", MoveTo }, {"go", MoveTo }, {"open", Open },
                {"close", Close }, {"pick", Pick},
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
                    packet.Client.Send("Say what?".Color(Ansi.yellow, Ansi.white).NewLine());
                    return;
                }
                if (!packet.parameter.HasLastCharPunctuation()) { packet.parameter += "."; }
                string message = "\"" + packet.parameter + "\"".NewLine().Color(Ansi.white);
                foreach (Connection player in packet.Client.Room.Players) {
                    if (player.Account.Name == packet.Client.Account.Name) {
                        player.Send("You say, ".Color(Ansi.white) + message.Color(Ansi.white));
                    } else {
                        player.Send(packet.Client.Account.Name + " says, ".Color(Ansi.white) + message.Color(Ansi.white));
                    }
                }
            } catch (Exception e) {
                settings.SystemMessageQueue.Push(e.ToString());
            }
        }

        private void Look(Packet packet) {
            string response = packet.Client.Room.GetName(), names = string.Empty;
            packet.Client.Send("".NewLine(), false);
            packet.Client.Send(response.Color(Ansi.cyan).NewLine());
            response = packet.Client.Room.GetDesciption();
            packet.Client.Send(response.Color(Ansi.white).WordWrap(), false);

            names = Functions.GetNames(packet.Client.Room.Exits.ToArray());
            if (names != string.Empty)
                response = "Obvious exits: " + names;
            else
                response = "No obvious exits.";

            packet.Client.Send(response.Color(Ansi.green).NewLine());

            names = string.Empty;
            if (packet.Client.Room.Players.Count > 1) {
                names = Functions.GetOtherNames(packet.Client.Room.Players.ToArray(), packet.Client.Account.Name);
                if (names != string.Empty)
                    packet.Client.Send("You see " + names.Color(false, Ansi.cyan, Ansi.bold).WordWrap().NewLine());
            }

            names = Functions.GetNames(packet.Client.Room.Mobs.ToArray());
            if (names != string.Empty)
                packet.Client.Send("You see " + names.Color(Ansi.green).NewLine());
            // add items
        }

        private void DontKnow(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) +
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine());
        }

        private void Shout(Packet packet) {
            DontKnow(packet);
        }

        private void Tell(Packet packet) {
            DontKnow(packet);
        }

        private void Yell(Packet packet) {
            DontKnow(packet);
        }

        private void Talk(Packet packet) {
            DontKnow(packet);
        }

        private void Whisper(Packet packet) {
            DontKnow(packet);
        }

        private void Get(Packet packet) {
            DontKnow(packet);
        }

        private void Hide(Packet packet) {
            DontKnow(packet);
        }

        private void MoveTo(Packet packet) {
            // check room exit name is direction or specific, set up room message for either. ToDo
            // see if more than one exit starts with what was received
            int results = Functions.GetSameNameCount(packet.Client.Room.Exits.ToArray(), packet.parameter);            
            if (results > 1) {
                packet.Client.Send("Too ambiguous.".Color(Ansi.yellow).NewLine());
                return;
            }

            Exit exit = packet.Client.Room.Exits.Find(e => (e.Name.StartsWith(packet.parameter, StringComparison.OrdinalIgnoreCase)));
            if (exit == null) { throw new Exception("Room exit wasn't found in RoomCommands:MoveTo"); }
            Room nextRoom = exit.link;
            packet.Client.Room.RemovePlayer(packet.Client, exit.Name);
            nextRoom.AddPlayer(packet.Client);
        }

        private void Open(Packet packet) {
            DontKnow(packet);
        }

        private void Close(Packet packet) {
            DontKnow(packet);
        }

        private void Pick(Packet packet) {
            DontKnow(packet);
        }
    }
}

