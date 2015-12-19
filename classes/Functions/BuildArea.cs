using Mountain.classes.dataobjects;

namespace Mountain.classes.Functions {

    public class BuildArea {
        Area area { get; }
        areaType Type;
        Room LinkTo;

        public BuildArea(areaType type, Room linkTo = null) {
            area = new Area("Test Area", "A test area for command testing.");
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
            return area;
        }
    }
}
