using System;
using System.Collections.Generic;
using System.Linq;

namespace Mountain.classes.helpers {

    public class CommunicationCommands {
        private Dictionary<string, Action<VerbPacket>> List;
        ApplicationSettings settings;
        public List<string> Keys;

        public CommunicationCommands(ApplicationSettings appSettings) {
            settings = appSettings;
            LoadCommunications();
        }
        private void LoadCommunications() {
            List = new Dictionary<string, Action<VerbPacket>>(){
                {"say", Say},
                {"tell", Tell},
                {"yell", Yell},
                {"shout", Shout},
                {"talk", Talk},
                {"whisper", Whisper},
                {"broadcast", Broadcast}
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

        public bool InvokeCommand(string verb, VerbPacket packet) {
            if(List.ContainsKey(verb)) {
                List[verb](packet);
                return true;
            }
            return false;
        }

        private void Say(VerbPacket packet) {
            try {
                if (!packet.parameter.HasLastCharPunctuation()) { packet.parameter += "."; }
                string message = "\"" + packet.parameter + "\"".NewLine().Color(Ansi.white);
                foreach (Connection player in packet.Client.Room.Players) {
                    if (player.Account.Name == packet.Client.Account.Name) {
                        player.Send("You say, " + message, true);
                    }
                    else {
                        player.Send(packet.Client.Account.Name + " says, " + message, true);
                    }
                }
            } catch (Exception e) {
                settings.SystemMessageQueue.Push(e.ToString());
            }
        }

        private void Shout(VerbPacket packet) { }

        private void Tell(VerbPacket packet) { }

        private void Yell(VerbPacket packet) { }

        private void Talk(VerbPacket packet) { }

        private void Whisper(VerbPacket packet) { }

        private void Broadcast(VerbPacket packet) { }
    }
}
