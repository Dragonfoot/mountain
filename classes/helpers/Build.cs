using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.Items;

namespace Mountain.classes.helpers {

    public static class Build {

        public static Area AdminArea() { 
            string name, description;
            Area area = new classes.Area();
            area.Name = "Administration Complex";
            area.Description = "One of this worlds extraordinary wonders. It houses top minds from all the major worlds within our galaxy. " +
               "As well it houses the most advanced technological and military equipment available. All this in order to make this world " +
               "the leader in vital galactic government growth and management.";

            name = "Administration Control Center";
            description = "You see the nerve center of world operations unfold around you. Computer stations with white clad operators quietly " +
                "talking into headsets while they adjust controls and relay information, in a long line of cubicles fading into the distance on your " +
                "right. Radar and sonar sensors, routing maps and scheduling timers all glowing quietly above them. To your left are a long range of office " +
                "doors with armed guards filtering and recording those wanting accessing to each. ";
            Room controlRoom = Room(name, description);

            name = "Central Transit Hub";
            description = "Administration Transit Hub Lobby";
            Room transitHub = Room(name, description);

            LinkRooms(controlRoom, "Transit hub", transitHub, "Control Center");

            area.Rooms.Add(controlRoom);
            area.Rooms.Add(transitHub);

            return area;
        }

        public static Area DefaultArea() {
            string name, description;
            Area area = new classes.Area();
            area.Name = "Default Area";


            return area;
        }

        public static void LinkRooms(Room firstRoom, string firstExitName, Room secondRoom, string secondExitName) {
            Exit firstExit = new classes.Exit();
            firstExit.Name = firstExitName;
            firstExit.link = secondRoom;
            firstRoom.AddExit(firstExit);
            Exit secondExit = new classes.Exit();
            secondExit = new classes.Exit();
            secondExit.Name = secondExitName;
            secondExit.link = firstRoom;
            secondRoom.AddExit(secondExit);
        }

        public static Area Area() { // stub
            return new classes.Area();
        }

        public static Room Void() {  // stub
            return new classes.Room();
        }

        public static Room Room(string name, string description) {
            Room room = new classes.Room(name, description);
            return room;
        }

        public static Exit Exit() {
            return new classes.Exit();
        }

        public static Item Item() {
            return new Items.Item();
        }
       
    }
}
