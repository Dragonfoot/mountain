using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    class Mob : Character {
        protected List<Player> fighting;
        protected List<Player> friends;
        protected List<Player> associates;
        protected List<Mob> buddies;
        protected List<Mob> enemies;

        public Mob() {
            this.fighting = new List<Player>();
            this.friends = new List<Player>();
            this.associates = new List<Player>();
            this.buddies = new List<Mob>();
            this.enemies = new List<Mob>();
        }

        public override void Save() {  // future potential, advanced combat mob, store between stalking player sessions
        }
        public override void Load() {
        }
    }
}
