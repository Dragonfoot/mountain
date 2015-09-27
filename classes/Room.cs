using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Room : BaseObject {

        private BlockingCollection<Exit> exits;
        private BlockingCollection<Player> players;
        private BlockingCollection<Mob> mobs;
        private BlockingCollection<Item> items;

        protected ConcurrentQueue<Packet> events; // will sort out if these need to be threaded..
        protected ConcurrentQueue<Packet> msgs;
        protected Queue<Packet> innerQueue;

        public Room() {
        }

        protected bool Save() {
            return false;
        }
        protected bool Load() {
            return false;
        }

        protected Packet PopQueue() {
            return new Packet(this, packetType.command, new DataPacket());
        }
        protected void PushQueue(Packet p) {
        }

    }
}
