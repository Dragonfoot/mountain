using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    [XmlRoot("Area")]
    public class Rooms {
        [XmlArray("Rooms")]
        public List<Room> List { get; set; }

        public Rooms() {
            List = new List<Room>();
        }
    }
}
