using System.Collections.Concurrent;
using Mountain.classes.dataobjects;
using Mountain.classes.Items;
using Mountain.classes.handlers;

namespace Mountain.classes.mobs {

    public class Underling : Identity { // mob precursor
        public Room Room; 
        public int Health { get; set; }  // dies at 0
        public int Strength { get; set; }  // carry, stamina, conditioning
        public int Intellegence { get; set; } // skills, spells, awareness         
        public int Level { get; set; }  // dexterity, experience, competence
        public int Attack { get; set; } // fighting ability, hit strength

        public ConcurrentBag<Item> Inventory { get; set; }
        public delegate void CommandHandler(object myObject, string message);
        public CommandHandler Handler;
        public MobCommands Commands;

        public Underling() {
            ClassType = classObjectType.mob;
            Inventory = new ConcurrentBag<Item>();
            Commands = new MobCommands();
            Health = 5;
            Strength = 3;
            Intellegence = 3;
            Level = 1;
            Attack = 0;
        }
    }
}
