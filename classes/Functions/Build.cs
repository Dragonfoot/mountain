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

            Room control;
            name = "Control Center";
            description = "You see the nerve center of world operations unfold around you. Computer stations line most of the walks with white clad technicians " +
                "murmuring with headsets, adjusting controls, issuing quiet command. Sensor arrays, blinking routing screens, schedulers dimly glowing " + 
                "above them, monitoring every aspect of this worlds events and activities. Off to your left, a long line of office doors, " +
                "uniformed guards challenging, filtering, and recording the movement of staff and visitors alike.";

            control = NewRoom(name, description, area);
            control.Tag = "Administration";
            control.roomType = roomType.admin | roomType.healing;
            control.roomRestrictons = roomRestrictions.fighting | roomRestrictions.taunting;
            control.roomConditions = roomConditions.magic | roomConditions.lawful;  

            Room transit;
            name = "Transit Hub";
            description = "Administration Transit Hub Main Entrance";

            transit = NewRoom(name, description, area);
            transit.Tag = "Administration";
            transit.roomType = roomType.path | roomType.shop | roomType.leveling;
            transit.roomRestrictons = roomRestrictions.magic | roomRestrictions.mindpower | roomRestrictions.fighting;
            transit.roomConditions = roomConditions.magic;


            Room theVoid; 
            name = "Void";
            description = "You find yourself weightlessly floating in some kind of silent, lonely, dark, " +
                "endless, - and as many other voidy spacy words there might be.. - space.";

            theVoid = NewRoom(name, description, area);
            GBL.Settings.TheVoid = theVoid;
            theVoid.Tag = "Void";
            theVoid.roomType = roomType.outdoor;
            theVoid.roomRestrictons = roomRestrictions.fighting | roomRestrictions.magic | roomRestrictions.mindpower | roomRestrictions.stealing;
 

            LinkTwoRooms(theVoid, transit);
            LinkTwoRooms(transit, control);
            LinkTwoRooms(control, theVoid);

            area.Rooms.Add(control);
            area.Rooms.Add(transit);
            area.Rooms.Add(theVoid);

            return area;
        }

        public static void LinkRoomTo(Room fromRoom, Room toRoom) {
            Exit exit = new Exit();
            exit.Name = fromRoom.Name + " Exit";
            exit.Description = exit.Name + " Description";
            exit.DoorLabel = toRoom.Name;
            exit.Area = toRoom.Area;
            exit.Room = toRoom;
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
