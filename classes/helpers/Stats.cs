//using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class Stats {   // list of possible player attributes set at arbitrary level 1 defaults
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
    }

}
