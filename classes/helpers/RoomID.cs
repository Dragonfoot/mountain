using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Mountain.classes.helpers {

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
