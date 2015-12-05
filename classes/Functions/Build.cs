using Mountain.classes.Items;
using Mountain.classes.dataobjects;

namespace Mountain.classes.functions {

    public static class Build {

        public static Area AdminArea() {
            string name, description;

            Area area = new Area();
            area.Name = "Administration Complex";
            area.Description = "One of this worlds most extraordinary wonders. Top minds from all the major centers reside here. " +
               "Houses the most advanced technological and military equipment available rivaling even Mount Cascade Fortress on " + 
               "Tavastazia's bloodless moon."; 

            Room controlROOM;
            name = "Control Center";
            description = "You see the nerve center of world operations unfold around you. Computer stations line most of the walks with white clad technicians " +
                "murmuring with headsets, adjusting controls, issuing quiet command. Sensor arrays, blinking routing screens, schedulers dimly glowing " + 
                "above them, monitoring every aspect of this worlds events and activities. Off to your left, a long line of office doors, " +
                "uniformed guards challenging, filtering, and recording the movement of staff and visitors alike.";

            controlROOM = NewRoom(name, description, area);
            controlROOM.Tag = "Administration";
            controlROOM.roomType = roomType.admin | roomType.healing;
            controlROOM.roomRestrictons = roomRestrictions.fighting | roomRestrictions.taunting;
            controlROOM.roomConditions = roomConditions.magic | roomConditions.lawful;  

            Room transitROOM;  // room used as exit hub from admin control room
            name = "Transit Hub";
            description = "Administration Transit Hub Main Entrance";

            transitROOM = NewRoom(name, description, area);
            transitROOM.Tag = "Administration";
            transitROOM.roomType = roomType.path | roomType.shop | roomType.leveling;
            transitROOM.roomRestrictons = roomRestrictions.magic | roomRestrictions.mindpower | roomRestrictions.fighting;
            transitROOM.roomConditions = roomConditions.magic;


            Room theVoidROOM;  // no doorway in for players and at least one exit to world room(s)
            name = "Void";
            description = "You find yourself weightlessly floating in some kind of silent, lonely, dark, " +
                "endless, - and as many other voidy spacy words there might be.. - space.";

            theVoidROOM = NewRoom(name, description, area);
            GBL.Settings.TheVoid = theVoidROOM;
            theVoidROOM.Tag = "Void";
            theVoidROOM.roomType = roomType.outdoor;
            theVoidROOM.roomRestrictons = roomRestrictions.fighting | roomRestrictions.magic | roomRestrictions.mindpower | roomRestrictions.stealing;
 

            LinkTwoRooms(theVoidROOM, transitROOM);
            LinkTwoRooms(transitROOM, controlROOM);
            LinkTwoRooms(controlROOM, theVoidROOM);

            area.Rooms.Add(controlROOM);
            area.Rooms.Add(transitROOM);
            area.Rooms.Add(theVoidROOM);

            return area;
        }

        public static void LinkRoomTo(Room fromRoom, Room toRoom) {
            Exit exit = new Exit();
            exit.Name = fromRoom.Name + " Exit";
            exit.Description = exit.Name + " Description";
            exit.DoorLabel = toRoom.Name;
            exit.Area = toRoom.Area;
            exit.Room = toRoom;
          //  exit.Linkage = new Location(toRoom);
            fromRoom.AddExit(exit);
        }

        public static void LinkTwoRooms(Room firstRoom, Room secondRoom) {
            LinkRoomTo(firstRoom, secondRoom);
            LinkRoomTo(secondRoom, firstRoom);
        }

        public static Area Area() { // stub
            return new Area();
        }

        public static Room NewRoom(string name, string description, Area area) { // stub
            return new Room(name, description, area);
        }        

        public static Item Item() {  // stub
            return new Item();
        }
    }
}
