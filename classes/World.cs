using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class World : BaseObject {
        protected List<Area> Areas;
        protected Task heart;

        public World() {
            this.Areas = new List<Area>();
            this.heart = new Task(new Action(this.HeartBeat));
        }

        public void Load(string filename) { }
        public void Save(string filename) { }
        public void Reload() { }
        public void Create() { }
        public void Clear() { }
        public void Shutdown() { }

        public void Stop() { }
        public void Start() { }

        private void HeartBeat() {
            // sanity checks : world loaded, areas are present..
            while (true) {
                // stopwatch.start()
                // foreach((Area)area in this.Areas){
                    // foreach((Room)room in area.Rooms){
                        // foreach((Mob)mob in room.Mobs){ run mob.tasks() } end foreach
                        // foreach((Player)player in room.Players){ run player.tasks() } end foreach
                        // run room.tasks()
                        // check UI, exit while(true) loop if requested
                    // } end foreach
                    // run area.tasks()
                //} end foreach
                // run world.tasks()
                // stopwatch.stop().display(stopwatch.duration())
                // check UI, exit while(true) loop if requested
            }
        }

    }

}
