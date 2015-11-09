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
        public MessageQueue InternalMessages;
        public Room Room { get; set; }
        public RoomID RoomID { get; set; }
        public Account UserAccount { get; set; }
        public ApplicationSettings settings;
        public string Nick { get; set; }

        public Player(TcpClient socket, Account user, ApplicationSettings appSettings)
            : base(socket, appSettings) {
            ClassType = classType.player; 
            base.baseMessageQueue.OnMessageReceived += OnPlayerMessageReceived;
            UserAccount = user;
            Nick = user.Name;
            Name = user.Name;
            settings = appSettings;
            InternalMessages = new MessageQueue(settings);
            InternalMessages.OnMessageReceived += Messages_OnInternalMessageReceived;
            Inventory = new ConcurrentBag<Item>();
            EnemyPlayers = new ConcurrentBag<Player>();
            EnemyMobs = new ConcurrentBag<Mob>();
            Equipment = new Equipment();
            Stats = new Stats();
            Commands = new CommandList(this, settings);
        }

        private void Messages_OnInternalMessageReceived(object myObject, string msg) {
            string message = InternalMessages.Pop();
            if (message.IsNullOrWhiteSpace()) { message = msg; }
            Send(message, true);
        }

        public void OnPlayerMessageReceived(object myObject, string msg) {
            string message = baseMessageQueue.Pop(); 
            if (message.IsNullOrWhiteSpace()) message = msg;
            VerbPacket packet = Parse(message, this);
            if (packet == null) {
                string verb = message.FirstWord();
                Send("I don't know what to do with \"".Color(Ansi.yellow) + verb.Color(Ansi.white) + "\" just yet.".Color(Ansi.yellow).NewLine(), true);
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
