using Mountain.classes.Items;
using Mountain.classes.dataobjects;

namespace Mountain.classes.functions {

    public static class Build {

        public static Area AdminArea(ApplicationSettings settings) {
            string name, description;

            Area area = new Area();
            area.Name = "Administration Complex";
            area.Description = "One of this worlds most extraordinary wonders. Top minds from all the major centers reside here. " +
               "Houses the most advanced technological and military equipment available rivaling even Mount Cascade Fortress on " + 
               "Tavastazia's bloodless moon."; 

            Room controlROOM;
            name = "Administration Control Center";
            description = "You see the nerve center of world operations unfold around you. Computer stations line most of the walks with white clad technicians " +
                "murmuring with headsets, adjusting controls, issuing quiet command. Sensor arrays, blinking routing screens, schedulers dimly glowing " + 
                "above them, monitoring every aspect of this worlds events and activities. Off to your left, a long line of office doors, " +
                "uniformed guards challenging, filtering, and recording the movement of staff and visitors alike.";

            controlROOM = NewROOM(name, description, settings, area);
            controlROOM.Tag = "Administration";
            controlROOM.roomType = roomType.admin | roomType.healing;
            controlROOM.roomRestrictons = roomRestrictionType.fighting | roomRestrictionType.taunting;
            controlROOM.roomConditions = roomConditionType.magic | roomConditionType.lawful;  

            Room transitROOM;  // room used as exit hub from admin control room
            name = "Central Transit Hub";
            description = "Administration Transit Hub Lobby";

            transitROOM = NewROOM(name, description, settings, area);
            transitROOM.roomType = roomType.path | roomType.shop | roomType.leveling;
            transitROOM.roomRestrictons = roomRestrictionType.magic | roomRestrictionType.mindpower | roomRestrictionType.fighting;
            transitROOM.roomConditions = roomConditionType.magic;


            Room theVoidROOM;  // no doorway in for players and at least one exit to world room(s)
            name = "The Unknown Place";
            description = "You find yourself weightlessly floating in some kind of silent, lonely, dark, " +
                "endless, and as many other voidy spacy words there might be.. space..";

            theVoidROOM = NewROOM(name, description, settings, area);
            settings.TheVoid = theVoidROOM;
            theVoidROOM.Tag = "Void";
            theVoidROOM.roomType = roomType.outdoor;
            theVoidROOM.roomRestrictons = roomRestrictionType.fighting | roomRestrictionType.magic | roomRestrictionType.mindpower | roomRestrictionType.stealing;


            ExitData TransitRoomExitData = new ExitData();
            TransitRoomExitData.Restrictions = exitRestrictionType.administration;
            TransitRoomExitData.DoorType = doorType.hasLock;
            TransitRoomExitData.LockType = lockType.pin;
            TransitRoomExitData.Name = "Control Center";

            ExitData controlRoomExitDATA = new ExitData();
            controlRoomExitDATA.Restrictions = exitRestrictionType.health;
            controlRoomExitDATA.Name = "Transit Hub";

            ExitData voidExitDATA = new ExitData();
            voidExitDATA.Restrictions = exitRestrictionType.health;
            voidExitDATA.DoorType = doorType.none;
            voidExitDATA.Name = "Known Place";

            LinkRoomTo(theVoidROOM, voidExitDATA, transitROOM);
            LinkTwoRooms(transitROOM, TransitRoomExitData, controlROOM, controlRoomExitDATA);            

            area.Rooms.Add(controlROOM);
            area.Rooms.Add(transitROOM);
            area.Rooms.Add(theVoidROOM);

            return area;
        }

        public static void LinkRoomTo(Room startRoom, ExitData data, Room toRoom) {
            Exit exit = new Exit();
            data.LinkToRoomID = new LinkToID(toRoom.Name, null, toRoom.Area.Name, toRoom);
            exit.link = toRoom;
            exit.Update(data);
            startRoom.AddExit(exit);
        }

        public static void LinkTwoRooms(Room firstRoom, ExitData firstExitData, Room secondRoom, ExitData secondExitData) {
            LinkRoomTo(firstRoom, firstExitData, secondRoom);
            LinkRoomTo(secondRoom, secondExitData, firstRoom);
        }

        public static Area Area() { // stub
            return new Area();
        }

        public static Room NewROOM(string name, string description, ApplicationSettings settings, Area area) { // stub
            return new Room(name, description, settings, area);
        }        

        public static Item Item() {  // stub
            return new Item();
        }
    }
}
