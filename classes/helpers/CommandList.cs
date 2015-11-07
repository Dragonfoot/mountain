using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class CommandList {
        private Dictionary<string, Action<VerbPacket>> CommunicationVerbs;
        public List<string> communicationKeys;

        public CommandList() {
            LoadCommands();
        }

        private void LoadCommands() {
            CommunicationVerbs = new Dictionary<string, Action<VerbPacket>>()
              {
                {"say", Say},
                {"tell", Tell},
                {"yell", Yell},
                {"talk", Talk},
                {"whisper", Whisper},
                {"broadcast", Broadcast}
              };
            communicationKeys = new List<string>(CommunicationVerbs.Keys);
        }

        public bool DoCommand(string verb, VerbPacket vp, Dictionary<string, Action<VerbPacket>> dictionary) {
            return false;
        }
        public bool IsVerb(string verb) {
            return communicationKeys.Any(key => key.StartsWith(verb));
        }
        public void DoAction(string verb, VerbPacket packet) {
            foreach (var cmd in CommunicationVerbs) {
                if (cmd.Key.Equals(verb)) {
                    cmd.Value.Invoke(packet);
                }
            }
        }

        private void Say(VerbPacket vp) {
            vp.player.Room.Messages.Push(vp.verb + " " + vp.parameter);
        }
        private void Tell(VerbPacket vp) {
            throw new NotImplementedException();
        }
        private void Yell(VerbPacket vp) {
            throw new NotImplementedException();
        }
        private void Talk(VerbPacket vp) {
            throw new NotImplementedException();
        }
        private void Whisper(VerbPacket vp) {
            throw new NotImplementedException();
        }
        private void Broadcast(VerbPacket vp) {
            throw new NotImplementedException();
        }

        public string ShowVerbs(int size) {
            string helplist = string.Join(", ", communicationKeys.ToArray());
            return helplist.WordWrap(size);
        }

    } // end commandList

}
