using System;
using System.Xml.Serialization;
using Mountain.classes.functions;

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
        public RoomID() { // for xml serialization only
        }
    }


    public class LinkToID : RoomID {
        [XmlIgnore]
        public Room Room { get; set; }
        public string LinkDoorLabel { get; set; }

        public LinkToID(string name, string linkDoorLabel, string area, Room room) : base(room.ID, name, area) {
            Room = room;
            if (Name.IsNullOrWhiteSpace()){
                if (name.IsNullOrWhiteSpace())
                    Name = linkDoorLabel;
            }
            LinkDoorLabel = (!linkDoorLabel.IsNullOrWhiteSpace()) ? linkDoorLabel : name;
        }

        public LinkToID() {
        }
    }
}
