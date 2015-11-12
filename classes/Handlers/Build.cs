using Mountain.classes.Items;
using Mountain.classes.dataobjects;

namespace Mountain.classes.handlers {

    public static class Build {

        public static Area AdminArea(ApplicationSettings settings) {
            string name, description;

            Area area = new classes.Area();
            area.Name = "Administration Complex";
            area.Description = "One of this worlds extraordinary wonders. It houses top minds from all the major worlds within our galaxy. " +
               "As well it houses the most advanced technological and military equipment available. All this in order to make this world " +
               "the leader in vital galactic government growth and management.";

            Room controlRoom;
            name = "Administration Control Center";
            description = "You see the nerve center of world operations unfold around you. You see computer stations with white clad technitians " +
                "mermering into headsets as they adjust controls and issue commands, in a long line of cubicles fading into the distance to your " +
                "right. Sensor arrays, routing maps and schedulers glowing quietly above them, monitoring every aspect of this worlds events and " +
                "activities. To your left, a long line of guarded office doors, guard challenging and recording those wanting access. ";
            controlRoom = Room(name, description, settings);
            controlRoom.Tag = "ControlCenter";

            Room transitHub;
            name = "Central Transit Hub";
            description = "Administration Transit Hub Lobby";
            transitHub = Room(name, description, settings);

            ExitAttributes controlExitAttributes = new ExitAttributes() {
                AdminOnly = true,
                Label = "Transit Hub"
            };
            ExitAttributes transitHubAttributes = new ExitAttributes() {
                AdminOnly = true,
                Label = "Control Center",
                Hidden = true,
            };                      
            LinkRooms(controlRoom, controlExitAttributes, transitHub, transitHubAttributes);

            Room theVoid;
            name = "The Empty Place";
            description = "You find youself weightlessly floating in some kind of silent, lonely, dark, " +
                "endless, and as many other voidy spacy words there might be.. space..";
            theVoid = new classes.Room(name, description, settings);
            theVoid.Tag = "Void";
            ExitAttributes voidExitAttributes = new ExitAttributes() {
                Label = "Return to the Known Place",
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
            Area area = new classes.Area();
            return area;
        }

        public static void LinkRooms(Room firstRoom, ExitAttributes first, Room secondRoom, ExitAttributes second) {
            Exit firstExit = new classes.Exit();
            firstExit.Attributes = first;
            firstExit.Name = firstExit.Attributes.Label;
            firstExit.link = secondRoom;
            firstExit.LinkToRoomName = secondRoom.Name;
            firstExit.LinkToRoomID = secondRoom.RoomID;
            firstRoom.AddExit(firstExit);

            Exit secondExit = new classes.Exit();
            secondExit = new classes.Exit();
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

        public static Room TheVoid(ApplicationSettings settings) {  // stub
            return new classes.Room(settings);
        }

        public static Room Room(string name, string description, ApplicationSettings settings) { // stub
            return new classes.Room(name, description, settings);
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
