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
        protected List<Item> inventory;  // need thread safe dynamic list and/or sorted?
        protected Equipment equipment;
        protected Stats stats;
        protected Vault vault;
        protected List<Player> enemyPlayers;
        protected List<Mob> enemyMobs; //
        private string password;
        private string nickname;

        public Player(TcpClient socket)
            : base(socket) {
            base.ClassType = classType.player;
            this.inventory = new List<Item>();
            this.equipment = new Equipment();
            this.enemyPlayers = new List<Player>();
            this.enemyMobs = new List<Mob>();
            this.stats = new Stats();
            this.vault = new Vault();
            this.password = string.Empty;
            this.nickname = string.Empty;
        }

        public void Save() {
            throw new NotImplementedException();
        }
        public void Load() {
            throw new NotImplementedException();
        }
        protected bool SaveToXml(string fileName) {
            try {
            } catch {
                return false;
            }
            return true;
        }
        protected bool LoadFromXml(string xml) {
            // create file backup with date/time last loaded
            // parse xml and populate properties
            // check if enemyMobs are still alive, remove others from list
            return true;
        }
        protected string Encrypt(string password) {
            return password;
        }
        protected string Decrypt(string password) {
            return password;
        }

    }
}
