
namespace Mountain.classes.dataobjects {

    public enum itemType {
        unknown, weapon, armour, money, consumable, clothing, valuables,
        text, container, ingredients, equipment
    }
    public enum classType {
        unknown, heart, player, client, room, mob, quest, timer,
        system, script, action, exit, item, keyLock, comboLock, pinLock
    }
    public enum equipmentLocation {
        unknown, head, eyes, face, neck, torso, shoulders, arms, wrists, hands, waist, thights,
        shins, feet, back, chest, weapon1, weapon2, shield, holding, undergarment
    }
    public enum itemSize {
        fitsAll, tiny, small, medium, large, huge
    }
    public static class Global {
        public const int indent = 1;
        public const int pWidth = 65;
    }
}
