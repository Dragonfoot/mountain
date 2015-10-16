using System;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    /* ansi color codes 
     * 
     http://pueblo.sourceforge.net/doc/manual/ansi_color_codes.html
     * 
     */

    public class Room : BaseObject {

        private List<Exit> exits;
        private List<Player> players;
        private List<Mob> mobs;
        private List<Item> items;

        protected ConcurrentQueue<Packet> events; // will sort out if these need to be threaded..
        protected ConcurrentQueue<Packet> msgs;
        protected Queue<Packet> innerQueue;

        public List<Exit> Exits {
            get {
                return this.exits;
            }
        }

        public Room() {
            this.exits = new List<Exit>();
            this.players = new List<Player>();
            this.mobs = new List<Mob>();
            this.items = new List<Item>();
            this.events = new ConcurrentQueue<Packet>();
            this.msgs = new ConcurrentQueue<Packet>();
            this.innerQueue = new Queue<Packet>();
            this.ID = new Guid();
            this.name = "New Room";
            this.description = "This is a newly created room";
        }

        public string[] View() {
            StringBuilder sb = new StringBuilder();
            string es;
            List<string> view = new List<string>();
            view.Add(this.name);
            view.Add("");
            view.Add(this.description);
            view.Add("");
            if (this.exits.Count > 0) { // exits
                sb.Append("Exits: ");
                for (int i = 0; i < exits.Count; i++) {
                    es = ((Exit)exits[i]).Name;
                    if (i != exits.Count - 1) {
                        es = es + ", ";
                    }
                    if (i == exits.Count - 1) {
                        es = es + ".";
                    }
                    sb.Append(es);
                }
                view.Add(sb.ToString());
                sb.Clear();
            }
            if (this.mobs.Count > 0) {
                sb.Append("Mobs: ");
                for (int i = 0; i < mobs.Count; i++) {
                    es = ((Mob)mobs[i]).Name;
                    if (i != mobs.Count - 1) {
                        es = es + ", ";
                    }
                    if (i == mobs.Count - 1) {
                        es = es + ".";
                    }
                    sb.Append(es);
                }
                view.Add(sb.ToString());
                sb.Clear();
            }
            if (this.players.Count > 0) {
                sb.Append("Players: ");
                for (int i = 0; i < players.Count; i++) {
                    es = ((Player)players[i]).Name;
                    if (i != players.Count - 1) {
                        es = es + ", ";
                    }
                    if (i == players.Count - 1) {
                        es = es + ".";
                    }
                    sb.Append(es);
                }                 
                view.Add(sb.ToString());
                sb.Clear();
            }
            // items on floor, need to search for duplicates and display them in a language friendly form
            // You see an orange, 23 pumpkin seeds, a hungry cat, Toetag's nose.
            // ie: a or an, 's, 2 or two..
            return view.ToArray();
        }

        public void AddExit(Exit exit) {
            this.exits.Add(exit);
        }
        public void AddMob(Mob mob) {
            this.mobs.Add(mob);
        }
        public void AddPlayer(Player player) {
            this.players.Add(player);
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
