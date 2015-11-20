using System.Collections.Generic;
using System.Xml.Serialization;
using Mountain.classes.Items;

namespace Mountain.classes.dataobjects {

    public class Equipment {       // possible player gear locations
        public Item head;
        public Item eyes;
        public Item face;
        [XmlArray("Neck_Items")] public List<Item> neck; // limited number of items per class/level/strength etc.
        public Item torso; // padding, armour, shirt..
        public Item shoulders;
        public Item arms;
        public Item leftWrist;
        public Item rightWrist;
        public Item leftHand;
        public Item rightHand;
        [XmlArray("Left_Hand_Fingers")] public List<Item> leftFingers;
        [XmlArray("Right_Hand_Fingers")] public List<Item> rightFingers;
        public Item waist;
        public Item thighs;
        public Item shins;
        public Item feet;
        public Item back;  // one shot throwing knife/axe/spear, or quiver?, backpack.. ~"throw mob 2; would check to see if he had a throw-able first
        public Item chest; // heavier plate armour, house banner, potion pockets, water-lung.. over top of torso armour for quick item access..
        public Item weapon1; // main hand
        public Item weapon2; // offhand
        public Item shield; // if not holding something or using offhand
        public Item holding; // any item that has the holdable flag set, torch, toetag's ear, divining rod of tracking..
        public Item underwear; // specialized armour type, ie: snake skin of.., tights of jumping..

        public Equipment() {
            this.neck = new List<Item>();
            leftFingers = new List<Item>();
            rightFingers = new List<Item>();
        }
    }
}
