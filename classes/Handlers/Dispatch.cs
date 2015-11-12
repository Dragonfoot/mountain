using System;
using System.Collections.Generic;
using System.Linq;
using Mountain.classes.tcp;
using Mountain.classes.dataobjects;

namespace Mountain.classes.handlers {

    public class Dispatch {
        private Connection Client;
        //  private Dictionary<string, Action<Packet>> playerCommands;
        //  private Dictionary<string, Action<Packet>> areaCommands;
        //  private Dictionary<string, Action<Packet>> worldCommands;
        private RoomCommands RoomCommands;
        private ApplicationSettings settings;

        public Dispatch(Connection client, ApplicationSettings appSettings) {
            this.settings = appSettings;
            this.Client = client;
            LoadCommands();
        }

        private void LoadCommands() {
            RoomCommands = new RoomCommands(settings);
        }
        public void InvokeCommand(string verb, Packet packet) {
            RoomCommands.InvokeCommand(verb, packet);
        }
        public bool DoCommand(string verb, Packet vp, Dictionary<string, Action<Packet>> dictionary) {
            return false;
        }
        public bool IsCommunicationVerb(string verb) {
            return RoomCommands.Keys.Any(key => key.StartsWith(verb));
        }


    } 

}
