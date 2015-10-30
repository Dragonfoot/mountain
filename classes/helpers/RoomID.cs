using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public struct RoomID {
        public Guid ID;
        public string Name;
        public RoomID(Guid id, string name) {
            ID = id;
            Name = name;
        }
    }
}
