using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes.Functions {

    public class BuildArea {
        Area area { get; }
        areaType Type;
        Room LinkTo;

        public BuildArea(areaType type, Room linkTo = null) {
            area = new Area("Undefined Area", "A default undefined area.");
            Type = type;
            LinkTo = linkTo;
        }

        private Room BuildRoomType(roomType type) {
            Room room = new Room(area);
            switch (type) {
                case roomType.road:
                    room.roomType = roomType.road;
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
            }
            return room;

        }
        private Area BuildHomeArea() {
            Area area = new Area("Home", "Default Home Area.");
            Room livingRoom = BuildRoomType(roomType.home);
            Build.LinkTwoRooms(LinkTo, livingRoom);
            livingRoom.Name = "Living Room";
            livingRoom.Description = "A warm and quiet room, fireplace alight with golden glow, slow patient crackling and " +
                "sweet tendrils of smoke emanate gently from within. A couch and two comfortably cushioned chairs cuddle closely " + 
                "towards the hearths gentleness. An archway brings the comforting smells of cooking in. A worn stairway " +
                "leads up on your left.";
            area.Rooms.Add(livingRoom);

            Room hallway = BuildRoomType(roomType.home);
            Build.LinkTwoRooms(livingRoom, hallway);
            hallway.Name = "Hallway";
            hallway.Description = "A dark narrow hallway joins the living room and the kitchen. Two doors, one on either, side break the length of the hall.";
            area.Rooms.Add(hallway);

            Room bathroom = BuildRoomType(roomType.home);
            Build.LinkTwoRooms(hallway, bathroom);
            bathroom.Name = "Little John";
            bathroom.Description = "The purpose if this room is evident by its plumbing and fixtures. Clean and organized, it still " +
                "gives off a gentle aroma of lavender, urine, and damp mildew.";
            area.Rooms.Add(bathroom);
             
            return area;
        }
    }
}
