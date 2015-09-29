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

        public void Reload() { }
        public void Clear() { }
        public void Shutdown() { }

        public void Stop() {
        }
        public void Start() {
            heart.Start();
        }

        public void Load(string world) {
            if (world != string.Empty) {
                // if world is a valid file - this.loadXml(world);
            }
            else this.CreateDefaultWorld(); 
        }

        public void CreateDefaultWorld() {
            base.name = "Default World";
            base.id = new Guid();
            base.description = "This world has been created by the Acme Corporate Funding Group for your life's passionate personal pleasures. " +
                "Keep your new world growing with us. /n" +
                "Invest in Acme Corporation's Life Insurance Policies and help make our gaming addition research goals a viable solution. " +
                "Become a gold member of our growing center of gaming excellence, do the right thing and " +
                "donate your soul to our world class Gaming Society Center of Excellence./n" +
                "Join today. (Please sign our body donor card, your body will be entered in our annual Grisly Corpse Competition Awards ceremony " +
                "and could win a place in our Achievements of Horror vault of our societies most fascinating players.)";
            this.CreateDefaultAdminArea();
            this.Save("defaultWorld");
        }

        private void CreateDefaultAdminArea() {
            Area area = new Area();
            
            Room room = new Room();
            // make new room ( admin.lobby )
            // make new room ( admin.office )
            // make new room ( admin.closet/lab/builder/training.. )
        }

        public void Save(string filename) {
            // check to see if we need to overwrite / update same world on disk
            // save
            // update properties settings for lastWorldSaved
        }

        private void HeartBeat() {
            // sanity checks : world loaded, areas present..
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
