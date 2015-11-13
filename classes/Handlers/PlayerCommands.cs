using System;
using System.Collections.Generic;
using System.Linq;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;

namespace Mountain.classes.handlers {

    public class PlayerCommands {

        private Dictionary<string, Action<Packet>> List;
        ApplicationSettings settings;
        public List<string> Keys;

        public PlayerCommands(ApplicationSettings appSettings) {
            settings = appSettings;
            LoadRoomCommands();
        }
        private void LoadRoomCommands() {
            List = new Dictionary<string, Action<Packet>>(){
                {"inventory", Invent},
                {"health", Health},
                {"equipment", Equip},
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



        private void Invent(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) +
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine(), true);
        }

        private void Health(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) +
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine(), true);
        }

        private void Equip(Packet packet) {
            packet.Client.Send("I don't know how to ".Color(Ansi.yellow) + packet.verb.Color(Ansi.white) +
                " yet. But I hope to soon.".Color(Ansi.yellow, Ansi.white).NewLine(), true);
        }
    }
}
