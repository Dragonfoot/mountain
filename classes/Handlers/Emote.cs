using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.handlers {

    public class Emote {
        public Dictionary<string, string> List;
        public string Verb;
        public string ActionSelf;
        public string ActionRoom;
        public string Reaction;

        public Emote() {
        }

        public void Add(string verb, string self, string room) {

        }
        public void Load(string name) { }
        public void Save(string name) { }
    }
}
