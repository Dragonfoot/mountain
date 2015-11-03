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
        protected ConcurrentBag<Player> enemyPlayers;
        protected ConcurrentBag<Mob> enemyMobs;
        protected ConcurrentBag<Item> inventory;
        protected Stats stats { get; set; }
        protected Equipment equipment { get; set; }
        public RoomID roomID { get; set; }
        private byte[] password { get; set; }
        private string screenName { get; set; }

        public Player(TcpClient socket)
            : base(socket) {
            ClassType = classType.player;
            inventory = new ConcurrentBag<Item>();
            enemyPlayers = new ConcurrentBag<Player>();
            enemyMobs = new ConcurrentBag<Mob>();
            equipment = new Equipment();
            stats = new Stats();
        }

        public virtual void Save() {
            throw new NotImplementedException();
        }
        public virtual void Load() {
            throw new NotImplementedException();
        }
        protected virtual string SaveXml(string fileName) {
            throw new NotImplementedException();
        }
        protected virtual bool LoadXml(string xml) {
            throw new NotImplementedException();
            // create file backup with date/time last loaded
            // parse xml and populate properties
            // check if enemyMobs are still alive, remove others from ConcurrentBag
            
        }
        protected byte[] Encrypt(string password) {
            byte [] encryptedPassword = new byte[64];
            return encryptedPassword;
        }
        protected string Decrypt(byte[] password) {
            return password.ToString();
        }

    }
}
