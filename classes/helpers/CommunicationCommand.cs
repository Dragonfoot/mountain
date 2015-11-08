using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class CommunicationCommands {
        private Dictionary<string, Action<VerbPacket>> List;
        public List<string> Keys;

        public CommunicationCommands() {
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
            PlayerEventPacket ePacket = new PlayerEventPacket(packet.verb, packet.parameter, packet.player);
            try {
                if (!packet.parameter.HasLastCharPunctuation()) { packet.parameter += "."; }
                foreach (Player player in packet.player.Room.Players) {
                    if (player.Name == packet.player.Name) {
                        player.Send("You say, \"" + packet.parameter + "\"".NewLine().Color(Ansi.white), true);
                    }
                    else {
                        player.Send(packet.player.Name + " says, \"" + packet.parameter + "\"".NewLine().Color(Ansi.white), true);
                    }
                }
             //   packet.player.Room.Messages.Push(ePacket);
            } catch (Exception e) {
                // Handle all other exceptions
            }
        }

        private void Shout(VerbPacket packet) {
            //   vp.player.Player.Send(vp.verb + " " + vp.parameter.Color(Ansi.white).NewLine(), true);
            //    vp.player.Room.Messages.Push(vp.verb + " " + vp.parameter);
        }

        private void Tell(VerbPacket packet) {
            // vp.player.Player.Send(vp.verb + " " + vp.parameter.Color(Ansi.white).NewLine(), true);
            // vp.player.Room.Messages.Push(vp.verb + " " + vp.parameter);
        }

        private void Yell(VerbPacket packet) {
            //  vp.player.Player.Send(vp.verb + " " + vp.parameter.Color(Ansi.white).NewLine(), true);
            //   vp.player.Room.Messages.Push(vp.verb + " " + vp.parameter);
        }

        private void Talk(VerbPacket packet) {
            //  vp.player.Player.Send(vp.verb + " " + vp.parameter.Color(Ansi.white).NewLine(), true);
            //   vp.player.Room.Messages.Push(vp.verb + " " + vp.parameter);
        }

        private void Whisper(VerbPacket packet) {
            //  vp.player.Player.Send(vp.verb + " " + vp.parameter.Color(Ansi.white).NewLine(), true);
            //   vp.player.Room.Messages.Push(vp.verb + " " + vp.parameter);
        }

        private void Broadcast(VerbPacket packet) {
            //vp.player.Player.Send(vp.verb + " " + vp.parameter.Color(Ansi.white).NewLine(), true);
            //   vp.player.Room.Messages.Push(vp.verb + " " + vp.parameter);
        }
    }
}
