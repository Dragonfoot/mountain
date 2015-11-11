using System.Collections.Generic;
using Mountain.classes.tcp;

namespace Mountain.classes.mobs {

    public class Mob : Underling {
        protected List<Connection> fightingPlayers;
        protected List<Connection> friendPlayers;
        protected List<Mob> mobBuddies;
        protected List<Mob> mobEnemies;

        public Mob() {
            Construct();
        }

        protected virtual void Construct() {
            this.fightingPlayers = new List<Connection>();
            this.friendPlayers = new List<Connection>();
            this.mobBuddies = new List<Mob>();
            this.mobEnemies = new List<Mob>();
        }       
    }
}
