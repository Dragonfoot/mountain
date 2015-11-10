using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Mountain.classes {

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
