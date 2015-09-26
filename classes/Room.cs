using System;
using System.Xml;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Room : BaseObject {

        private BlockingCollection<Exit> exits;
        private BlockingCollection<Player> players;
        private BlockingCollection<Mob> mobs;
        private BlockingCollection<Item> items;

        protected ConcurrentQueue<Packet> events;
        protected ConcurrentQueue<Packet> msgs;

        public Room() {
        }
        protected bool Save() {
            return false;
        }
        protected bool Load() {
            return false;
        }

    }
}
