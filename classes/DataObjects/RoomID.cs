using System;

namespace Mountain.classes.dataobjects {

    public class RoomID {
        public string Area { get; set; }
        public Guid ID { get; set; }
        public string Name { get; set; }

        public RoomID(Guid id, string name, string area) {
            ID = id;
            Name = name;
            Area = area;
        }
        public RoomID() {
        }
    }
}
