using System.Collections.Generic;
using Mountain.classes.Items;

namespace Mountain.classes {
    public class Equipment {       // possible player gear locations
        protected Item head;
        protected Item eyes;
        protected Item face;
        protected List<Item> neck; // limited number of items per class/level/strength etc.
        protected Item torso;
        protected Item shoulders;
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
        protected Item undergarment; // specialized armour type, ie: snake skin of poison deflection, tights of jumping..

        public Equipment() {
            this.neck = new List<Item>();
        }
    }
}
