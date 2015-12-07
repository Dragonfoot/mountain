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
            fightingPlayers = new List<Connection>();
            friendPlayers = new List<Connection>();
            mobBuddies = new List<Mob>();
            mobEnemies = new List<Mob>();
        }       
    }
}
