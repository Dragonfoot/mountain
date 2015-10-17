using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class World : BaseObject {
        protected Server portListener;
        protected List<Area> Areas;
        protected Task heart;
        protected bool heartStop;
        protected CancellationTokenSource tokenSource;
        protected CancellationToken token;

        public World(string world) {
            this.Areas = new List<Area>();
            this.heartStop = false;
            tokenSource = new CancellationTokenSource();
            this.token = tokenSource.Token;
            this.heart = Task.Factory.StartNew(() => HeartBeat(), token);
            Load(world);
            portListener = new Server();
        }

        public void Reload() { }
        public void Clear() { }
        public void Shutdown() { }

        public void Stop() {
            tokenSource.Cancel();
            tokenSource.Dispose();
            portListener.Stop();
        }
        public void Start() {
            heart.Start();
            portListener.Start();
        }

        public void Load(string world) {
            if (world != string.Empty) {
                // if world is a valid file - this.loadXml(world);
            } else {
                // notify console of error and
                CreateDefaultWorld();
            }
        }

        public void CreateDefaultWorld() {
            base.name = "Default World";
            base.ID = new Guid();
            base.description = "This world has been created by the Toetag Corporate Funding Group for your life's passionate pleasures. " +
                "Keep your new world growing with us. /n" +
                "Invest in Toetag Corporation's Life Insurance Policies and help make our gaming addition goals a viable solution. " +
                "Become a gold member of our growing centers of excellence, do the right thing, " +
                "donate your soul to our world class Gaming Society Center of Excellence. You could win big!/n" +
                "Join today. (Please sign our body donor card and be entered in our annual Grisly Corpse Competition Awards ceremony. " +
                "You could win a place on the top shelf of our Achievements of Horror vault that houses the very best souls of our societies " +
                "most fascinating players.)";
            this.CreateDefaultAdminArea();
            this.Save("defaultWorld");
        }

        private void CreateDefaultAdminArea() {
            Area area = new Area();
            // set area data
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
                        // check UI, exit while(true)loop if required
                    // } end foreach
                    // run area.tasks()
                //} end foreach
                // run world.tasks()
                // stopwatch.stop().display(stopwatch.duration())
                // check GUI and exit while(true) loop if requested
                if (this.heartStop == true) break;
            }
        }

    }

}
