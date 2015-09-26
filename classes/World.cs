using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.helpers;
using Mountain.classes.Interfaces;

namespace Mountain.classes {

    public class World : IStorable {

        protected BlockingCollection<Area> Areas;
        protected Heart heart;

        public World() {
        }
        void IStorable.Load() {
        }
        void IStorable.Save() {
        }

    }

}
