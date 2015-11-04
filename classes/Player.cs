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
        public RoomID RoomID { get; set; }
        public Account UserAccount { get; set; }
        public string NickName { get; set; }

        public Player(TcpClient socket, Account user)
            : base(socket) {
            ClassType = classType.player; 
            UserAccount = user;
            NickName = user.Name;
            messageQueue.OnMessageReceived += OnMessageReceived; 
            Inventory = new ConcurrentBag<Item>();
            EnemyPlayers = new ConcurrentBag<Player>();
            EnemyMobs = new ConcurrentBag<Mob>();
            Equipment = new Equipment();
            Stats = new Stats();
        }
        protected void OnMessageReceived(object myObject) {
        }

        protected virtual string Save(string fileName) {
            throw new NotImplementedException();
        }
        protected virtual bool Load(string fileName) {
            throw new NotImplementedException();            
        }

    }
}
