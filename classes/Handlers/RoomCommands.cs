using System;
using System.Collections.Generic;
using System.Linq;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;
using Mountain.classes.functions;

namespace Mountain.classes.handlers {

    public class RoomCommands {

        private Dictionary<string, Action<Packet>> List;
        private StringResponses Resource;
        ApplicationSettings settings;
        public List<string> Keys;

        public RoomCommands(ApplicationSettings appSettings) {
            settings = appSettings;
            Resource = new StringResponses();
            LoadRoomCommands();
        }
        private void LoadRoomCommands() {
            List = new Dictionary<string, Action<Packet>>(){
                {"say", Say}, {"tell", Tell}, {"yell", Yell}, {"shout", Shout}, {"talk", Talk}, {"whisper", Whisper},
                {"look", Look }, {"get", Get }, {"hide", Hide }, {"go", MoveTo }, {"open", Open },
                {"close", Close }, {"pick", Pick}, {"quit", Quit }
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


        public void DontKnowYet(Packet packet) {
            packet.Client.Send(Resource.DontKnowHow(packet.verb, packet.Client));
        }

        private void Say(Packet packet) {
            try {
                if (packet.parameter.IsNullOrWhiteSpace()) {
                    packet.Client.Send("Say what?".Ansi(Style.yellow, Style.white).NewLine());
                    return;
                }
                if (!packet.parameter.HasLastCharPunctuation()) { packet.parameter += "."; }
                string message = "\"" + packet.parameter + "\"".NewLine().Ansi(Style.white);
                foreach (Connection player in packet.Client.Room.Players) {
                    if (player.Account.Name == packet.Client.Account.Name) {
                        player.Send("You say, ".Ansi(Style.white) + message.Ansi(Style.white));
                    } else {
                        player.Send(packet.Client.Account.Name + " says, ".Ansi(Style.white) + message.Ansi(Style.white));
                    }
                }
            } catch (Exception e) {
                settings.SystemMessageQueue.Push(e.ToString());
            }
        }

        private void Look(Packet packet) {
            string response = packet.Client.Room.GetName(), names = string.Empty;
            packet.Client.Send("".NewLine(), false);
            packet.Client.Send(response.Ansi(Style.cyan).NewLine());
            response = packet.Client.Room.GetDesciption();
            packet.Client.Send(response.Ansi(Style.white).WordWrap(), false);

            names = Functions.GetNames(packet.Client.Room.Exits.ToArray());
            if (names != string.Empty)
                response = "Obvious exits: " + names;
            else
                response = "No obvious exits.";

            packet.Client.Send(response.Ansi(Style.green).NewLine());

            names = string.Empty;
            if (packet.Client.Room.Players.Count > 1) {
                names = Functions.GetOtherNames(packet.Client.Room.Players.ToArray(), packet.Client.Account.Name);
                if (names != string.Empty)
                    packet.Client.Send("You see:" + names.Ansi(true, Style.cyan, Style.boldOn).WordWrap().NewLine());
            }

            names = Functions.GetNames(packet.Client.Room.Mobs.ToArray());
            if (names != string.Empty)
                packet.Client.Send("You see:" + names.Ansi(Style.green).NewLine());
            // add items
        }

        private void Quit(Packet packet) {
            settings.Players.Remove(packet.Client.Account.Name, "Player has left.");
            packet.Client.Send("See you again soon!".Ansi(Style.white).NewLine().NewLine());
            packet.Client.Room.Players.Remove(packet.Client.Account.Name);
            SystemEventPacket eventPacket = new SystemEventPacket(EventType.disconnected, packet.Client.Account.Name + " has left.", packet.Client);
            settings.SystemEventQueue.Push(eventPacket);
            packet.Client.Shutdown();
            packet.Client.Dispose();
        }
        private void Shout(Packet packet) {
            DontKnowYet(packet);
        }

        private void Tell(Packet packet) {
            DontKnowYet(packet);
        }

        private void Yell(Packet packet) {
            DontKnowYet(packet);
        }

        private void Talk(Packet packet) {
            DontKnowYet(packet);
        }

        private void Whisper(Packet packet) {
            DontKnowYet(packet);
        }

        private void Get(Packet packet) {
            DontKnowYet(packet);
        }

        private void Hide(Packet packet) {
            DontKnowYet(packet);
        }

        private void MoveTo(Packet packet) {
            // check room exit name is direction or specific, set up room message for either. ToDo
            // see if more than one exit starts with what was received

            // make sure we have a room first, before attempting to actually go there
            int results = Functions.GetSameNameCount(packet.Client.Room.Exits.ToArray(), packet.parameter);            
            if (results > 1) {
                packet.Client.Send("Too ambiguous.".Ansi(Style.yellow).NewLine());
                return;
            }

            Exit exit = packet.Client.Room.Exits.Find(e => (e.Name.StartsWith(packet.parameter, StringComparison.OrdinalIgnoreCase)));
            if (exit == null) {
                DontKnowYet(packet);
                return;
            }
            Room nextRoom = exit.link;
            packet.Client.Room.RemovePlayer(packet.Client, exit.Name);
            nextRoom.AddPlayer(packet.Client);
        }

        private void Open(Packet packet) {
            DontKnowYet(packet);
        }

        private void Close(Packet packet) {
            DontKnowYet(packet);
        }

        private void Pick(Packet packet) {
            DontKnowYet(packet);
        }
    }
}

