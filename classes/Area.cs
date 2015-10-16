using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Area : BaseObject {
        protected List<Room> rooms;
        public List<Room> Rooms {
            get {
                return this.rooms;
            }
        }
        public string Name {
            get {
                return base.name;
            }
            set {
                base.name = value;
            }
        }
        public string Description {
            get {
                return base.description;
            }
            set {
                base.description = value;
            }
        }

        public Area() {
            base.name = "unknown area name";
            base.description = "new generic area";
            base.ID = new Guid();
        }
        public Area(string name, string description, Guid id) {
            this.Name = name;
            this.Description = description;
            this.ID = id;
        }
    }
}
