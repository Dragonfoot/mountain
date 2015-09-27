using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Area : BaseObject {
        protected BlockingCollection<Room> Rooms;

        public Area() {
        }
    }
}
