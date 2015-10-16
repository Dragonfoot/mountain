using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Mob : Dummy {
        protected List<Player> playerFighting;
        protected List<Player> playerFriends;
        protected List<Player> playerAssociates;
        protected List<Mob> mobBuddies;
        protected List<Mob> mobEnemies;

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
            this.playerFighting = new List<Player>();
            this.playerFriends = new List<Player>();
            this.playerAssociates = new List<Player>();
            this.mobBuddies = new List<Mob>();
            this.mobEnemies = new List<Mob>();
        }
       
    }
}
