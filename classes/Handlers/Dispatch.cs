using System;
using System.Linq;
using Mountain.classes.tcp;
using Mountain.classes.dataobjects;

namespace Mountain.classes.handlers {

    [Serializable] public class Dispatch {
        private Connection Client;
        //  private Dictionary<string, Action<Packet>> areaCommands;
        //  private Dictionary<string, Action<Packet>> worldCommands;
        private RoomCommands RoomCommands;
        private PlayerCommands PlayerCommands;

        public Dispatch(Connection client) {
            Client = client;
            LoadCommands();
        }

        private void LoadCommands() {
            RoomCommands = new RoomCommands();
            PlayerCommands = new PlayerCommands();
        }

        public void InvokeCommand(string verb, Packet packet) {
            if (RoomCommands.Keys.Any(key => key.StartsWith(verb))) {
                RoomCommands.InvokeCommand(verb, packet);
                return;
            }
            if (PlayerCommands.Keys.Any(key => key.StartsWith(verb))) {
                PlayerCommands.InvokeCommand(verb, packet);
                return;
            }
        } 
        public void DontKnowHow(Packet command) {
            RoomCommands.DontKnowYet(command);
        }

        public bool IsCommand(string verb) {
            if (RoomCommands.Keys.Any(key => key.StartsWith(verb))) return true;            
            if (PlayerCommands.Keys.Any(key => key.StartsWith(verb))) return true;            
            return false;
        }
    } 
}
