using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Area : Identity {
        public List<Room> Rooms { get; private set; }
        public bool Active { get; set; }

        public Area() {
            Name = "new area";
            Description = "new area";
        }
        public Area(string name, string description, Guid id) {
            Name = name;
            Description = description;
            ID = id;
        }

        public void Load(string fileName) {
        }
        public void Save(string fileName) {
        }
        public void UnloadRooms() { // resource management
        }
        public void ReloadRooms() { // resource management
        }

    }
}
