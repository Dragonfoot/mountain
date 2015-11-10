using System;
using System.Collections.Generic;
using System.Linq;

namespace Mountain.classes.helpers {

    public class Dispatch {
        private Connection Client;
      //  private Dictionary<string, Action<VerbPacket>> RoomFunctions;
      //  private Dictionary<string, Action<VerbPacket>> InternalFunctions;
        private CommunicationCommands Communications;
        private ApplicationSettings settings;

        public Dispatch(Connection client, ApplicationSettings appSettings) {
            this.settings = appSettings;
            this.Client = client;
            LoadCommands();
        }

        private void LoadCommands() {
            Communications = new CommunicationCommands(settings);
        }
        public void InvokeCommand(string verb, VerbPacket packet) {
            Communications.InvokeCommand(verb, packet);
        }
        public bool DoCommand(string verb, VerbPacket vp, Dictionary<string, Action<VerbPacket>> dictionary) {
            return false;
        }
        public bool IsCommunicationVerb(string verb) {
            return Communications.Keys.Any(key => key.StartsWith(verb));
        }


    } 

}
