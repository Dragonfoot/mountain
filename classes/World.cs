using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class World : BaseObject {

        protected BlockingCollection<Area> Areas;
        protected Thread heart;

        public World() {
            this.Areas = new BlockingCollection<Area>();
            this.heart = new Thread(new ThreadStart(this.HeartBeat));
            heart.IsBackground = true;
            heart.Name = "Heart Beat";
        }
        public void Load() {
        }
        public void Save() {
        }
        public void Stop() {
           // this.heart.Stop();
        }
        public void Start() {
            this.heart.Start();
            while(!heart.IsAlive) ;
        }
        public void CreateWorld() {
        }
        public void ClearWorld() {
        }


        private void HeartBeat() {
            while (true) {
                Thread.Sleep(30000);
            }
        }

    }

}
