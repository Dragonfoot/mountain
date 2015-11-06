using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using Mountain.classes.helpers;
using Mountain.classes.Items;

namespace Mountain.classes {

    public class Player : ClientConnection {
        protected ConcurrentBag<Player> EnemyPlayers;
        protected ConcurrentBag<Mob> EnemyMobs;
        protected ConcurrentBag<Item> Inventory;
        protected Stats Stats { get; set; }
        protected Equipment Equipment { get; set; }
        protected CommandList Commands { get; set; }
        public RoomID RoomID { get; set; }
        public Account UserAccount { get; set; }
        public string Nick { get; set; }

        public Player(TcpClient socket, Account user)
            : base(socket) {
            ClassType = classType.player; 
            UserAccount = user;
            Nick = user.Name;
            Name = user.Name;
            base.messageQueue.OnMessageReceived += OnPlayerMessageReceived; 
            Inventory = new ConcurrentBag<Item>();
            EnemyPlayers = new ConcurrentBag<Player>();
            EnemyMobs = new ConcurrentBag<Mob>();
            Equipment = new Equipment();
            Stats = new Stats();
            Commands = new CommandList();
            Send("Ready".Color(Ansi.yellow).NewLine(), true);
        }

        public void OnPlayerMessageReceived(object myObject, string msg) {
            string message = messageQueue.Pop(); // pull the message
            if (message.IsNullOrWhiteSpace()) message = msg;

            VerbPacket packet = Parse(message, UserAccount);
            if (packet == null) {
                string verb = message.FirstWord();
                Send("I don't know what to do with \"".Color(Ansi.yellow) + verb.Color(Ansi.white) + "\" just yet.".Color(Ansi.yellow).NewLine(), true);
                string help = Commands.ShowVerbs(45).TrimStart(' ');
                Send("For now I recognize ".Color(Ansi.yellow) + help.Color(Ansi.white).NewLine(), true);
                return;
            }
            string response = "\"" + packet.verb + "\" - " + packet.parameter;
            Send(response.Color(Ansi.white).NewLine(), true);
        }

        public void Shutdown() {
            Send("Shutting down now.".Color(Ansi.yellow), false);
            base.ClientSocket.Close();
            Save();
        }
        private void SetRoom(RoomID id) {
            RoomID = id;
            UserAccount.RoomID = id;
        }
        protected virtual void Save() {
            //throw new NotImplementedException();
        }
        protected virtual bool Load() {
            //throw new NotImplementedException();            
            return false;
        }
        private VerbPacket Parse(string str, Account user) {
            str = str.TrimStart(' ');
            str = str.StripExtraSpaces();
            string verb = str.FirstWord();
            if (Commands.IsVerb(verb)) {
                string tail = str.StripFirstWord().ToLower();
                VerbPacket packet = new VerbPacket(verb, tail);
                return packet;
            }
            return null;
        }     
    }
}
