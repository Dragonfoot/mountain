using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.helpers;
using Mountain.classes.Interfaces;

namespace Mountain.classes {

    public class Room : BaseObject, IStorable {

        private BlockingCollection<Exit> exits;
        private BlockingCollection<Player> players;
        private BlockingCollection<Mob> mobs;
        private BlockingCollection<Item> items;

        protected ConcurrentQueue<Packet> events;
        protected ConcurrentQueue<Packet> msgs;

        public Room() {
        }
        void IStorable.Save() {
        }
        void IStorable.Load() {
        }

    }
}
