using Mountain.classes.dataobjects;
using System.Xml.Serialization;

namespace Mountain.classes {

    public class Exit : Identity {
        [XmlIgnore] public Room link { get; set; }
        public string LinkToRoomName;
        public RoomID LinkToRoomID;
        public ExitAttributes Attributes { get; set; }

        public Exit() {
            ClassType = classType.exit;
        }
    }

}