using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class CommandList {
        private Player player { get; set; }
        private Dictionary<string, Action<VerbPacket>> RoomFunctions;
        private Dictionary<string, Action<VerbPacket>> InternalFunctions;
        private CommunicationCommands Communications;

        public CommandList(Player player) {
            this.player = player;
            LoadCommands();
        }

        private void LoadCommands() {
            Communications = new CommunicationCommands();
        }        

        public bool DoCommand(string verb, VerbPacket vp, Dictionary<string, Action<VerbPacket>> dictionary) {
            return false;
        }
        public bool IsCommunicationVerb(string verb) {
            return Communications.Keys.Any(key => key.StartsWith(verb));
        }


    } // end commandList

}
