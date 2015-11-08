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
        public MessageQueue Messages { get; set; }
        public Room Room { get; set; }
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
            Messages = new MessageQueue();
            Messages.OnMessageReceived += Messages_OnMessageReceived;
            Inventory = new ConcurrentBag<Item>();
            EnemyPlayers = new ConcurrentBag<Player>();
            EnemyMobs = new ConcurrentBag<Mob>();
            Equipment = new Equipment();
            Stats = new Stats();
            Commands = new CommandList(this);
        }

        private void Messages_OnMessageReceived(object myObject, string msg) {
            string message = Messages.Pop();
            if (message.IsNullOrWhiteSpace()) { message = msg; }
            Send(message, true);
        }

        public void OnPlayerMessageReceived(object myObject, string msg) {
            string message = messageQueue.Pop(); 
            if (message.IsNullOrWhiteSpace()) message = msg;
            VerbPacket packet = Parse(message, this);
            if (packet == null) {
                string verb = message.FirstWord();
                Send("I don't know what to do with \"".Color(Ansi.yellow) + verb.Color(Ansi.white) + "\" just yet.".Color(Ansi.yellow).NewLine(), true);
                // string help = Commands.ShowVerbs(45).TrimStart(' ');
                if (Commands.IsCommunicationVerb(verb)) {
                    Send("But, um.. I did a few minutes ago..\"scratch\"".Color(Ansi.yellow).NewLine(), true);
                }
                string str = message.TrimStart(' ');
                str = str.StripExtraSpaces();
                string command = str.FirstWord();
                string tail = str.StripFirstWord();
                string response = command + " \"" + tail.Trim() + "\"";
                Send(response.Color(Ansi.cyan).NewLine(), true);
                return;
            }
            Commands.InvokeCommand(packet.verb, packet);
        }

        public new void Send(string msg, bool indent) {
            base.Send(msg, indent);
        }

        public void Shutdown() {
            Send("Shutting down now.".Color(Ansi.yellow), false);
            base.ClientSocket.Close();
            Save();
        }

        private void SetRoom(Room room) {
            Room = room;
            UserAccount.RoomID = room.RoomID;
            UserAccount.Room = room;
        }

        protected virtual void Save() {
            //throw new NotImplementedException();
        }

        protected virtual bool Load() {
            //throw new NotImplementedException();            
            return false;
        }

        private VerbPacket Parse(string str, Player player) {
            string verb, tail = string.Empty;
            str = str.TrimStart(' ');
            str = str.StripExtraSpaces();
            if (str.FirstChar() == '\'') {
                verb = "say";
                tail = str.StripFirstChar();
                tail = tail.TrimStart(' ');
            }
            else {
                verb = str.FirstWord();
                if (verb == "say") { tail = str.StripFirstWord(); }
                else { tail = str.StripFirstWord().ToLower(); }
            }
            if (Commands.IsCommunicationVerb(verb)) {                
                VerbPacket packet = new VerbPacket(verb, tail, player);
                return packet;
            }
            return null;
        }     
    }
}
