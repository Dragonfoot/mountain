using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Mob : Underling {
        protected List<Player> fightingPlayers;
        protected List<Player> friendPlayers;
        protected List<Player> associatePlayers;
        protected List<Mob> mobBuddies;
        protected List<Mob> mobEnemies;

        public string Description {
            get { return base.Description; }
            set { base.Description = value; }
        }

        public Mob() {
            base.ClassType = classType.mob;
            Construct();
        }

        protected virtual void Construct() {
            this.fightingPlayers = new List<Player>();
            this.friendPlayers = new List<Player>();
            this.associatePlayers = new List<Player>();
            this.mobBuddies = new List<Mob>();
            this.mobEnemies = new List<Mob>();
        }       
    }
}
