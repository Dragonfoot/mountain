using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Area : Identity {
        protected List<Room> rooms;
        public List<Room> Rooms {
            get {
                return this.rooms;
            }
        }
        public string Description {
            get {
                return base.Description;
            }
            set {
                base.Description = value;
            }
        }

        public Area() {
            Name = "unknown area name";
            base.Description = "new generic area";
            base.ID = Guid.NewGuid();
        }
        public Area(string name, string description, Guid id) {
            this.Name = name;
            this.Description = description;
            this.ID = id;
        }
    }
}
