using System;

namespace Mountain.classes.dataobjects {

    public enum itemType {
        unknown, weapon, armour, money, consumable, clothing, valuables,
        text, container, ingredients, equipment, none
    }
    public enum itemSize {
        fitsAll, tiny, small, medium, large, huge
    }
    public enum classType {
        unknown, heart, player, client, room, mob, quest, timer, world, area,
        system, script, action, exit, item, keyLock, comboLock, pinLock
    }
    [Flags] public enum roomType {
        unknown = 0, path = 1, street = 2, road = 4, sewer = 8, space = 16, water = 32, plains = 64,
        forest = 128, mountain = 256, underground = 512, indoor = 1024, outdoor = 2048, administrator = 4096
    }
    [Flags] public enum charType {
        barbarian = 0, fighter = 1, ranger = 2, mage = 4, monk = 8, druid = 16, assassin = 32, thief = 64, psychic = 128,
        paladin = 256, bard = 512, alcamist = 1024, cleric = 2048, diplomat = 4096
    }
    public enum exitType {
        door, open, closed, hidden, visible, locked, unlocked, random, teleporter, trapped, directional
    }
    [Flags] public enum lockType {
        combo, key, password, pin, owner, spell, trapped, questItem, pickable, restricted
    }
    [Flags] public enum restrictionType {
        level, administration, race, character, size, magic, quest
    }

    public enum equipmentLocation {
        unknown, head, eyes, face, neck, torso, shoulders, arms, wrists, hands, waist, thighs,
        shins, feet, back, chest, weapon1, weapon2, shield, holding, undergarment
    }
    public enum seasons {
        spring, summer, autumn, winter
    }
    public enum climateZone {
        artic, temperate, tropical, dry, humid
    } 
    [Flags] public enum weatherVisibility {
        clear, cloud, overcast, rain, storm, snow, fog, mist, smoke, haze, wind, glow
    }
    [Flags] public enum consciousState {
        unknown = 1, awake = 1, asleep = 2, drunk = 4, confused = 8, unconscious = 16,
        zonked = 32, hypnotized = 64, spaced = 128, drugged = 256, paralized = 512, dead = 1024
    }
    public enum genderTypes {
        unknown, nueter, male, female, asexual
    }



    public static class Global {
        public const int indent = 1;
        public const int pageWidth = 65;
    }
}

