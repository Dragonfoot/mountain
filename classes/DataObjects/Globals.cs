using System;

namespace Mountain.classes.dataobjects {
    
    [Flags] public enum roomType {
        none = 0, path = 1, street = 2, road = 4, sewer = 8, outdoor = 16, admin = 32, home = 64, vault = 128,
        leveling = 256, cave = 512, shop = 1024, pawn = 2048, healing = 4096
    }

    [Flags] public enum roomConditions {
        none = 0, dark = 1, foul = 2, water = 4, space = 8, magic = 16, lawful = 32, draining = 64, poisonous = 128
    }

    [Flags]
    public enum roomRestrictions {
        none = 0, fighting = 1, stealing = 2, magic = 4, mindpower = 8, taunting = 16, vocalizing = 32
    }

    [Flags] public enum charType {
        none = 0, fighter = 1, ranger = 2, mage = 4, monk = 8, druid = 16, assassin = 32, thief = 64, psychic = 128,
        paladin = 256, bard = 512, alcamist = 1024, cleric = 2048, diplomat = 4096, barbarian = 8192
    }

    [Flags] public enum doorType {
        none = 0, open = 1, visible = 2, hasLock = 4, 
    }

    [Flags] public enum exitRestrictions {
        none = 0, level = 1, administration = 2, race = 4, character = 8, size = 16, magic = 32, quest = 64, health = 128
    }

    [Flags] public enum consciousState {
        none = 0, awake = 1, asleep = 2, drunk = 4, confused = 8, unconscious = 16,
        intermittant = 32, hypnotized = 64, spaced = 128, drugged = 256, paralized = 512, dead = 1024
    }

    public enum roomItem {
        roomType, roomLimits, roomTraits
    }

    public enum weatherVisibility {
        clear, cloud, overcast, rain, storm, snow, fog, mist, smoke, haze, wind, glow, eyeWatering
    }

    public enum Style {
        reset, boldOn, dim, italic, ul, boldOff, italicOff, ulOff, black, red, green, yellow, blue, magenta, cyan,
        white, blackBk, redBk, greenBK, yellowBk, blueBk, magentaBk, cyanBk, whiteBk, clearScreen
    }

    public enum itemType {
        unknown, weapon, armour, money, consumable, clothing, valuables,
        text, container, ingredients, equipment, none
    }

    public enum itemSize {
        fitsAll, tiny, small, medium, large, huge
    }

    public enum classObjectType {
        unknown, heart, player, client, room, mob, quest, timer, world, area,
        system, script, action, exit, item, keyLock, comboLock, pinLock
    }

    public enum exitType {
        door, window, random, teleport, openSpace
    }

    public enum lockType {
        broken, key, pin, owner, spell, skill, item, password
    }

    public enum direction {
        none, east, north, west, south, down, up
    }

    public enum equipmentLocation {
        unknown, head, eyes, face, neck, torso, shoulders, arms, wrists, hands, waist, thighs,
        shins, feet, back, chest, weapon1, weapon2, shield, holding, undergarment
    }

    public enum seasonType {
        unknown, spring, summer, autumn, winter
    }

    public enum climateZone {
        none, artic, temperate, tropical, dry, humid
    } 

    public enum genderTypes {
        unknown, nueter, male, female, asexual
    }

    public enum raceType {
        human, dwarf, elf, giant, halfElf, halfDwarf, halfGiant
    }

    public static class GBL {
        public const int indent = 1;
        public const int pageWidth = 65;
        public static ApplicationSettings Settings;
    }
}

