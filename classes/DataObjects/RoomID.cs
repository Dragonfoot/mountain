using System;

namespace Mountain.classes.dataobjects {

    public class RoomID {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public RoomID(Guid id, string name) {
            ID = id;
            Name = name;
        }
        public RoomID() {
        }
    }
}
