using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class World {

        protected BlockingCollection<Area> Areas;
        protected Heart heart;

        public World() {
        }
        public void Load() {
        }

    }

}
