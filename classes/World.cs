using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class World : BaseObject {

        protected BlockingCollection<Area> Areas;
        protected Heart heart;

        public World() {
            this.heart = new Heart();
            this.Areas = new BlockingCollection<Area>();
            // load and start heart;
        }
        public void Load() {
        }

    }

}
