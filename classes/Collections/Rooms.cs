using System.Collections.Generic;
using System.Xml.Serialization;

namespace Mountain.classes.collections {

    [XmlRoot("Area")]
    public class Rooms {
        [XmlArray("Rooms")]
        public List<Room> List { get; set; } 

        public Rooms() {
            List = new List<Room>();
        }
    }
}
