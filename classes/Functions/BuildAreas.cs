using Mountain.classes.dataobjects;
using Mountain.classes.functions;

namespace Mountain.classes.functions {

    public static class BuildAreas {

        public static Area AreaType(areaType type, Room fromHere = null) {
            return BuildAreaType(type, fromHere);
        }

        private static Area BuildAreaType(areaType type, Room fromHere) {
            Area area = null;
            switch (type) {
                case areaType.home:
                    area = BuildHomeArea(fromHere);  // setup restrictions, weather, unique stats ...
                    break;
                default:
                    area = new Area("Undefined Area", "A default undefined area.");
                    break;
            }
            return area;
        }

        private static Area BuildHomeArea(Room IncomingLink) {
            Area area = new Area("Home", "Default Home Area.");
            Room livingRoom = BuildRoom.Type(roomType.home, area);
            livingRoom.Name = "Living Room";
            livingRoom.Description = "A warm and quiet room, fireplace alight with golden glow, slow patient crackling and " +
                "sweet tendrils of smoke emanate gently from within. A couch and two comfortably cushioned chairs cuddle closely " + 
                "towards the hearths gentleness. An archway brings the comforting smells of cooking in. A worn stairway " +
                "leads up on your left.";
            if (IncomingLink != null) { Build.LinkRoomTo(IncomingLink, livingRoom); }
            area.Rooms.Add(livingRoom);

            Room hallway = BuildRoom.Type(roomType.home, area);
            hallway.Name = "Hallway";
            hallway.Description = "A dark narrow hallway joins the living room and the kitchen. Two doors, one on either, side break the length of the hall.";
            Build.LinkTwoRooms(livingRoom, hallway);
            area.Rooms.Add(hallway);

            Room bathroom = BuildRoom.Type(roomType.home, area);
            bathroom.Name = "Little John";
            bathroom.Description = "The purpose if this room is evident by its plumbing and fixtures. Clean and organized, it still " +
                "gives off a gentle aroma of lavender, urine, and damp mildew.";
            Build.LinkTwoRooms(hallway, bathroom);
            area.Rooms.Add(bathroom);

            Room hallCloset = BuildRoom.Type(roomType.home, area);
            hallCloset.Name = "Closet";
            hallCloset.Description = "Brooms, dustbins, cleaning solutions are all neatly organized in this tiny space.";
            Build.LinkTwoRooms(hallway, hallCloset);
            area.Rooms.Add(hallCloset);

            Room kitchen = BuildRoom.Type(roomType.home, area);
            kitchen.Name = "Kitchen";
            kitchen.Description = "A bright warm room with all the cooking smells one would expect from a well lived in, healthy families, home.";
            Build.LinkTwoRooms(hallway, kitchen);
            area.Rooms.Add(kitchen);

            Room backyard = BuildRoom.Type(roomType.home, area);
            backyard.Name = "Back Yard";
            backyard.Description = "Back Yard Area Description";
            Build.LinkTwoRooms(kitchen, backyard);
            area.Rooms.Add(backyard);

            Room basement = BuildRoom.Type(roomType.home, area);
            basement.Name = "Basement";
            basement.Description = "Basement Description";
            Build.LinkTwoRooms(kitchen, basement);
            kitchen.Exits[1].DoorLabel = "Door";
            area.Rooms.Add(basement);

            Room upstairsHall = BuildRoom.Type(roomType.home, area);
            upstairsHall.Name = "Upstairs Hallway";
            upstairsHall.Description = "Upstairs hallway description";
            Build.LinkTwoRooms(livingRoom, upstairsHall);
            upstairsHall.Exits[0].DoorLabel = "Down Stairs";
            area.Rooms.Add(upstairsHall);
             
            return area;
        }
    }
}
