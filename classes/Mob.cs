using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Mob : Dummy {
        protected List<Player> fightingPlayers;
        protected List<Player> friendPlayers;
        protected List<Player> associatePlayers;
        protected List<Mob> mobBuddies;
        protected List<Mob> mobEnemies;
        protected List<Item> inventory;

        public string Name {
            get {
                return base.name;
            }
            set {
                base.name = value;
            }
        }
        public Mob() {
            Construct();
        }

        protected virtual void Construct() {
            this.fightingPlayers = new List<Player>();
            this.friendPlayers = new List<Player>();
            this.associatePlayers = new List<Player>();
            this.mobBuddies = new List<Mob>();
            this.mobEnemies = new List<Mob>();
            this.inventory = new List<Item>();
        }
       
    }
}
