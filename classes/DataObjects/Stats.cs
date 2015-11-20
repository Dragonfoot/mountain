using System.Collections.Generic;
using Mountain.classes.functions;

namespace Mountain.classes.dataobjects {

    public class Stats {   // list of possible player attributes set at arbitrary level 1 defaults
        public int health = 18;
        public int level = 1;
        public int strength = 4;
        public int constitution = 4;
        public int dexterity = 3;
        public int intellegence = 3;
        public int stealth = 1;
        public int mana = 0;
        public int wisdom = 3;
        public int awareness = 4;
        public double luck = 0.01;
        public double intuition = 0.01;
        public int experience = 0;
        public int maxItemWeight = 18;
        public int coins = 5;
        public List<string> skills;
        public List<string> spells;
        public List<string> powers;
        public List<string> languages;
        protected charType CharType;

        public Stats() {
            this.skills = new List<string>();
            this.spells = new List<string>();
            this.powers = new List<string>();
            this.languages = new List<string>();
        }

        public string HealthPrompt() {
            string prompt = "".NewLine() + "{".Color(Ansi.green) + "{0} HP - {1} IP".Color(Ansi.cyan) + "}".Color(Ansi.green).NewLine();
            prompt = prompt.Replace("{0}", health.ToString());
            prompt = prompt.Replace("{1}", mana.ToString());
            return prompt;
        }
    }

}
