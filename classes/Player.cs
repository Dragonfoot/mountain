using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Concurrent;
using Mountain.classes.helpers;

namespace Mountain.classes {
    
    class Player : Character {
        protected List<Item> inventory;  // need thread safe dynamic list and/or sorted?
        protected Equipment equipment;
        protected Stats stats;
        protected List<Player> madPlayers;
        protected List<Mob> madMobs; //
        private string password;
        private string nickname;

        public Player() {
            this.inventory = new List<Item>();
            this.equipment = new Equipment();
            this.madPlayers = new List<Player>();
            this.madMobs = new List<Mob>();
            this.stats = new Stats();
        }
        protected bool SaveToXml(string fileName) {
            try {
                using (XmlWriter writer = XmlWriter.Create(fileName)) {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Player");
                    writer.WriteAttributeString("Name", base.Name);
                    writer.WriteAttributeString("GUID", base.ID.ToString());
                    writer.WriteAttributeString("Description", base.Description);
                    writer.WriteAttributeString("Password", Encrypt(this.password));
                    writer.WriteAttributeString("NickName", this.nickname);
                    //continue looping through lists/stats/equipment/enemies etc
                    // close off elements/document, rename old file, move old old file to backup?, save
                }
            } catch {
                return false;
            }
            return true;
        }
        protected bool LoadFromXml(string xml) {
            // create restore point with clone of this file on disk with date/time last loaded
            // parse xml and populate properties
            // check if madMobs are still alive, remove others from list
            return true;
        }
        protected string Encrypt(string password) {
            return password;
        }
        protected string Decrypt(string password) {
            return password;
        }


    }

    class Equipment {       // possible player gear locations
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

    class Stats {   // list of possible player attributes set at arbitrary level 1 defaults
        protected int health = 18;
        protected int maxHealth = 18;
        protected int strength = 4;
        protected int constitution = 4;
        protected int dexterity = 3;
        protected int intellegence = 3;
        protected int stealth = 1;
        protected int mana = 0;
        protected int maxMana = 0;
        protected int wisdom = 3;
        protected int awareness = 4;
        protected double luck = 0.01;
        protected double intuition = 0.01;
        protected int experience = 0;
        protected int maxItemWeight = 18;
        protected int coins = 5;
        protected List<string> skills;
        protected List<string> spells;
        protected List<string> powers;
        protected List<string> languages;
        protected string charClass = "generic";
        protected string weaponClass = "unknown";

        public Stats() {
            this.skills = new List<string>();
            this.spells = new List<string>();
            this.powers = new List<string>();
            this.languages = new List<string>();
        }
        protected XmlWriter GetProperties(XmlWriter xml) {
            // store properties into writer and return it to calling object
            return xml;
        }
    }

}
