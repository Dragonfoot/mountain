using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using Mountain.classes.helpers;

namespace Mountain.classes {
    
    public class Player : Character {
        protected List<Item> inventory;  // need thread safe dynamic list and/or sorted?
        protected Equipment equipment;
        protected Stats stats;
        protected Vault vault;
        protected List<Player> enemyPlayers;
        protected List<Mob> enemyMobs; //
        private string password;
        private string nickname;

        public string Name {
            get {
                return base.name;
            }
            set {
                base.name = value;
            }
        }

        public Player(TcpClient socket) : base(socket) {
            this.inventory = new List<Item>();
            this.equipment = new Equipment();
            this.enemyPlayers = new List<Player>();
            this.enemyMobs = new List<Mob>();
            this.stats = new Stats();
            this.vault = new Vault();
            this.password = string.Empty;
            this.nickname = string.Empty;
        }

        public override void Save() {
            throw new NotImplementedException();
        }
        public override void Load() {
            throw new NotImplementedException();
        }
        protected bool SaveToXml(string fileName) {  // will use the static xml helper class to do this when it's ready, 
            try {
               /* using (XmlWriter writer = XmlWriter.Create(fileName)) { // logic layout proof of concept...
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Player");
                    writer.WriteAttributeString("Name", base.name);
                    writer.WriteAttributeString("GUID", base.id.ToString());
                    writer.WriteAttributeString("Description", base.description);
                    writer.WriteAttributeString("Password", Encrypt(this.password));
                    writer.WriteAttributeString("NickName", this.nickname);
                    //continue looping through lists/stats/equipment/enemies etc
                    // close off elements/document, rename old file, move old old file to backup?, save */
                }
            catch {
                return false;
            }
            return true;
        }
        protected bool LoadFromXml(string xml) {
            // create restore point with clone of this file on disk with date/time last loaded
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

    public class Equipment {       // possible player gear locations
        protected Item head;
        protected Item eyes;
        protected Item face;
        protected List<Item> neck; // limited number of items per class/level/strength etc.
        protected Item torso;
        protected Item sholders;
        protected Item arms;
        protected Item wrists;
        protected Item hands; //perhaps fingers for magical items?
        protected Item waist;
        protected Item thighs;
        protected Item shins;
        protected Item feet;
        protected Item back;  // one shot throwing knife/axe/spear, or quiver?, backpack.. ~"throw mob 2; would check to see if he had a throw-able first
        protected Item chest; // house banner, potion pockets, waterlung.. overtop of torso armour for quick item access, vulnerable?
        protected Item weapon1; // main hand
        protected Item weapon2; // offhand
        protected Item shield; // if not holding something or using offhand
        protected Item holding; // any item that has the holdable flag set, torch, toetag's ear, divining rod of tracking..
        protected Item undergarment; // specialized armour type, ie: skin of poison deflection, tights of girded strength..

        public Equipment() {
            this.neck = new List<Item>();
        }

    }

    

   


}
