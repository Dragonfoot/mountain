using System;
using System.Xml.Serialization;

namespace Mountain.classes.dataobjects {

    [Serializable] public class Linkage {
        [XmlIgnore] public Area Area { get; set; }
        [XmlIgnore] public Room Room { get; set; }
        public string AreaName { get { return Area.Name; } }
        public string RoomName { get { return Room.Name; } }
        public string DoorLabel { get; set; }

        public Linkage(string doorLabel, Area area, Room room)  {
            Area = area;
            Room = room;
            DoorLabel = doorLabel;
        }

        public Linkage ShallowCopy() {
            return (Linkage)MemberwiseClone();
        }

        public Linkage() {
        }
    }
}
