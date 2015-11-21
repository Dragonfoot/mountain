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
              

            Room controlRoom;
            name = "Administration Control Center";
            description = "You see the nerve center of world operations unfold around you. Computer stations line most of the walks with white clad technicians " +
                "murmuring with headsets, adjusting controls, issuing quiet command. Sensor arrays, blinking routing screens, schedulers dimly glowing " + 
                "above them, monitoring every aspect of this worlds events and activities. Off to your left, a long line of office doors, " +
                "uniformed guards challenging, filtering, and recording the movement of staff and visitors alike.";

            controlRoom = NewRoom(name, description, settings, area);
            controlRoom.Tag = "ControlCenter";
            controlRoom.roomType = roomType.indoor | roomType.administrator | roomType.underground;

            Room transitHub;  // room used as exit hub from admin control room
            name = "Central Transit Hub";
            description = "Administration Transit Hub Lobby";
            transitHub = NewRoom(name, description, settings, area);
            transitHub.roomType = roomType.indoor | roomType.administrator;

            ExitAttributes controlExitAttributes = new ExitAttributes() {
                AdminOnly = true,
                Label = "Transit Hub"
            };
            ExitAttributes transitExitAttributes = new ExitAttributes() {
                AdminOnly = true,
                Label = "Control Center",
                Hidden = true,
            };  
                                
            LinkRooms(controlRoom, controlExitAttributes, transitHub, transitExitAttributes);

            Room theVoid;  // no doorway in for players and one exit to arbitrary world room
            name = "The Unknown Place";
            description = "You find yourself weightlessly floating in some kind of silent, lonely, dark, " +
                "endless, and as many other voidy spacy words there might be.. space..";

            theVoid = NewRoom(name, description, settings, area);
            settings.TheVoid = theVoid;
            theVoid.Area = area;
            theVoid.Tag = "Void";
            theVoid.roomType = roomType.space;
            ExitAttributes voidExitAttributes = new ExitAttributes() {
                Label = "Known Place",
            };

            Exit voidExit = Exit(voidExitAttributes);
            voidExit.link = transitHub;
            theVoid.AddExit(voidExit);
            area.Rooms.Add(controlRoom);
            area.Rooms.Add(transitHub);
            area.Rooms.Add(theVoid);

            return area;
        }

        public static Area DefaultArea() { // stub
            Area area = new Area();
            return area;
        }

        public static void LinkRooms(Room firstRoom, ExitAttributes first, Room secondRoom, ExitAttributes second) {
            Exit firstExit = new Exit();
            firstExit.Attributes = first;
            firstExit.Name = firstExit.Attributes.Label;
            firstExit.link = secondRoom;
            firstExit.LinkToRoomName = secondRoom.Name;
            firstExit.LinkToRoomID = secondRoom.RoomID;
            firstRoom.AddExit(firstExit);

            Exit secondExit = new Exit();
            secondExit = new Exit();
            secondExit.Attributes = second;
            secondExit.Name = secondExit.Attributes.Label;
            secondExit.link = firstRoom;
            secondExit.LinkToRoomName = firstRoom.Name;
            secondExit.LinkToRoomID = firstRoom.RoomID;
            secondRoom.AddExit(secondExit);
        }

        public static Area Area() { // stub
            return new classes.Area();
        }

        public static Room NewRoom(string name, string description, ApplicationSettings settings, Area area) { // stub
            return new Room(name, description, settings, area);
        }

        public static Exit Exit(ExitAttributes attributes) { 
            Exit exit =  new classes.Exit();
            exit.Attributes = attributes;
            exit.Name = attributes.Label;
            return exit;
        }

        public static Item Item() {  // stub
            return new Items.Item();
        }
       
    }
}
