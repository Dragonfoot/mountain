using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net.Sockets;
using Mountain.classes.helpers;
using Mountain.classes.Interfaces;

namespace Mountain.classes {
    
    class Player : Character {
        protected List<Item> inventory;  // need thread safe dynamic list and/or sorted?
        protected Equipment equipment;
        protected Stats stats;

        public Player() {
            this.inventory = new List<Item>();
            this.equipment = new Equipment();
            this.stats = new Stats();
        }
        protected bool SaveToXml(string fileName) {
            try {
                using (XmlWriter writer = XmlWriter.Create(fileName)) {
                    writer.WriteStartDocument();
                    writer.WriteStartElement("Player");
                    writer.WriteAttributeString("Name", base.name);
                    writer.WriteAttributeString("GUID", base.id.ToString());
                    writer.WriteAttributeString("Description", base.description);

                }
            } catch {
                return false;
            }
            /* using (XmlWriter writer = XmlWriter.Create("employees.xml"))
	            {
	                writer.WriteStartDocument();
	                writer.WriteStartElement("Employees");

	                foreach (Employee employee in employees)
	                {
		            writer.WriteStartElement("Employee");

		            writer.WriteElementString("ID", employee.Id.ToString());
		            writer.WriteElementString("FirstName", employee.FirstName);
		            writer.WriteElementString("LastName", employee.LastName);
		            writer.WriteElementString("Salary", employee.Salary.ToString());

		            writer.WriteEndElement();
	                }

	                writer.WriteEndElement();
	                writer.WriteEndDocument();
	            } */



            // grab properties and add to xml
            return true;
        }
        protected bool LoadFromXml(string xml) {
            // parse xml and populate properties
            return true;
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
        }

    }

    class Stats {   // list of possible player attributes set at debatable level 1 defaults
        protected int health = 18;
        protected int maxHealth = 18;
        protected int strength = 9;
        protected int constitution = 6;
        protected int dexterity = 3;
        protected int mana = 0;
        protected int maxMana = 0;
        protected int wisdom = 3;
        protected int awareness = 4;
        protected double luck = 0.01;
        protected double intuition = 0.01;
        protected int experience = 0;
        protected int intellegence = 3;
        protected int maxItemWeight = 18;
        protected int coins = 5;
        protected List<string> skills;
        protected List<string> spells;
        protected List<string> powers;
        protected List<string> languages;
        protected string charClass = "Fighter";

        public Stats() {
            this.skills = new List<string>();
            this.spells = new List<string>();
            this.powers = new List<string>();
            this.languages = new List<string>();
        }
        protected XmlWriter GetProperties(XmlWriter xml) {

            return xml;
        }
    }

}
