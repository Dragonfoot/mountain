using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes.Functions {

    public class BuildArea {
        public Area area { get; private set; }
        Room IncomingLink;

        public BuildArea(areaType type, Room fromHere = null) {
            IncomingLink = fromHere;
            BuildAreaType(type);
        }

        private void BuildAreaType(areaType type) {
            switch (type) {
                case areaType.home:
                    area = BuildHomeArea();  // setup restrictions, weather, unique stats ...
                    break;
                default:
                    area = new Area("Undefined Area", "A default undefined area.");
                    break;
            }
        }

        private Room BuildRoomType(roomType type) {
            Room room = new Room(area);
            switch (type) {
                case roomType.road:
                    room.roomType = roomType.road; // set up possible speed limits, healing rates, leveling restrictions...
                    break;
                case roomType.path:
                    room.roomType = roomType.path;
                    break;
                case roomType.street:
                    room.roomType = roomType.street;
                    break;
                case roomType.healing:
                    room.roomType = roomType.healing;
                    break;
                case roomType.home:
                    room.roomType = roomType.home;
                    break;
                case roomType.leveling:
                    room.roomType = roomType.leveling;
                    break;
                case roomType.pawn:
                    room.roomType = roomType.pawn;
                    break;
                case roomType.shop:
                    room.roomType = roomType.shop;
                    break;
                case roomType.sewer:
                    room.roomType = roomType.sewer;
                    break;
                case roomType.vault:
                    room.roomType = roomType.vault;
                    break;
                default: room.roomType = roomType.none;
                    break;
            }
            return room;

        }
        private Area BuildHomeArea() {
            Area area = new Area("Home", "Default Home Area.");
            Room livingRoom = BuildRoomType(roomType.home);
            livingRoom.Name = "Living Room";
            livingRoom.Description = "A warm and quiet room, fireplace alight with golden glow, slow patient crackling and " +
                "sweet tendrils of smoke emanate gently from within. A couch and two comfortably cushioned chairs cuddle closely " + 
                "towards the hearths gentleness. An archway brings the comforting smells of cooking in. A worn stairway " +
                "leads up on your left.";
            if (IncomingLink != null) { Build.LinkTwoRooms(IncomingLink, livingRoom); }
            area.Rooms.Add(livingRoom);

            Room hallway = BuildRoomType(roomType.home);
            hallway.Name = "Hallway";
            hallway.Description = "A dark narrow hallway joins the living room and the kitchen. Two doors, one on either, side break the length of the hall.";
            Build.LinkTwoRooms(livingRoom, hallway);
            area.Rooms.Add(hallway);

            Room bathroom = BuildRoomType(roomType.home);
            bathroom.Name = "Little John";
            bathroom.Description = "The purpose if this room is evident by its plumbing and fixtures. Clean and organized, it still " +
                "gives off a gentle aroma of lavender, urine, and damp mildew.";
            Build.LinkTwoRooms(hallway, bathroom);
            area.Rooms.Add(bathroom);

            Room hallCloset = BuildRoomType(roomType.home);
            hallCloset.Name = "Closet";
            hallCloset.Description = "Brooms, dustbins, cleaning solutions are all neatly organized in this tiny space.";
            Build.LinkTwoRooms(hallway, hallCloset);
            area.Rooms.Add(hallCloset);

            Room kitchen = BuildRoomType(roomType.home);
            kitchen.Name = "Kitchen";
            kitchen.Description = "A bright warm room with all the cooking smells one would expect from a well lived in, healthy families, home.";
            Build.LinkTwoRooms(hallway, kitchen);
            area.Rooms.Add(kitchen);

            Room backyard = BuildRoomType(roomType.home);
            backyard.Name = "Back Yard";
            backyard.Description = "Back Yard Area Description";
            Build.LinkTwoRooms(kitchen, backyard);
            area.Rooms.Add(backyard);

            Room basement = BuildRoomType(roomType.home);
            basement.Name = "Basement";
            basement.Description = "Basement Description";
            Build.LinkTwoRooms(kitchen, basement);
            area.Rooms.Add(basement);

            Room upstairsHall = BuildRoomType(roomType.home);
            upstairsHall.Name = "Upstairs Hallway";
            upstairsHall.Description = "Upstairs hallway description";
            Build.LinkTwoRooms(livingRoom, upstairsHall);
            area.Rooms.Add(upstairsHall);
             
            return area;
        }
    }
}
