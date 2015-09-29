using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Room : BaseObject {

        private List<Exit> exits;
        private List<Player> players;
        private List<Mob> mobs;
        private List<Item> items;

        protected ConcurrentQueue<Packet> events; // will sort out if these need to be threaded..
        protected ConcurrentQueue<Packet> msgs;
        protected Queue<Packet> innerQueue;

        public Room() {
            this.exits = new List<Exit>();
            this.players = new List<Player>();
            this.mobs = new List<Mob>();
            this.items = new List<Item>();
            this.events = new ConcurrentQueue<Packet>();
            this.msgs = new ConcurrentQueue<Packet>();
            this.innerQueue = new Queue<Packet>();
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
