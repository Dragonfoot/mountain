using System;
using System.Linq;
using System.Collections.Generic;
using Mountain.classes.dataobjects;

namespace Mountain.classes.functions {

    public static class Functions {

        public static string FormatStringArray(Array list) {
            string names = string.Empty;
            int i = 0;
            foreach (string item in list) {
                names += item;
                if (i != list.Length) { names += ", "; }
                if (i == list.Length) { names += "."; }
            }
            return names;
        }

        public static string GetNames(Array list) {
            string names = string.Empty;
            int i = 1;
            foreach (Identity item in list) {
                names = names + item.Name;
                if (i != list.Length) { names = names + ", "; }
                if (i == list.Length) { names = names + "."; }
                i++;
            }
            return names;
        }

        public static IEnumerable<T> GetValues<T>() { // loop through enums: var values = GetValues<Foos>();
            return (T[])Enum.GetValues(typeof(T));
        }

        public static int GetSameNameCount(Array list, string name) {
            int i = 0;
            foreach(Identity item in list) {
                if (item.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase)) { i++; }
            }
            return i;
        }

        public static string GetOtherNames(Array list, string name) {
            string names = string.Empty;
            int i = 1;
            foreach (Identity item in list) {
                if(item.Name == name) { i++; continue; }
                names = names + item.Name;
                if (i != list.Length) { names = names + ", "; }
                if (i == list.Length) { names = names + "."; }
                i++;
            }
            return names;
        }

        public static bool HasNameThatStartsWith(Array list, string name) {
            foreach(Identity item in list) {
                if (item.Name.StartsWith(name, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public static Room CloneRoomToEdit(Room room, ApplicationSettings settings) {  // switch to extension.deepclone?
            Room clone = new Room(room.Name, room.Description, settings, room.Area);
            clone.RoomID = room.RoomID;
            clone.roomType = room.roomType;
            clone.Tag = room.Tag;
            clone.ID = room.ID;
            if (room.Exits.Any()) {
                foreach (Exit exit in room.Exits) {
                    Exit clonedExit = new Exit();
                    clonedExit.ID = exit.ID;
                    clonedExit.Name = exit.Name;
                    clonedExit.Description = exit.Description;
                    clonedExit.link = exit.link;
                    clonedExit.parent = exit.parent;
                    clonedExit.LinkID = new LinkToID(exit.LinkID.Name, exit.LinkID.LinkDoorLabel, exit.LinkID.Area, exit.LinkID.Room);
                    clonedExit.Open = exit.Open;
                    clonedExit.Lockable = exit.Lockable;
                    clonedExit.Visible = exit.Visible;
                    clonedExit.Repairable = exit.Repairable;
                    clonedExit.ExitType = exit.ExitType;
                    clonedExit.LockType = exit.LockType;
                    clonedExit.DoorType = exit.DoorType;
                    clonedExit.Restrictions = exit.Restrictions;
                    clone.AddExit(clonedExit);
                }
            }
            return clone;
        }

        public static void UpdateRoomEdits(Room fromRoom, Room toRoom) {
            toRoom.Name = fromRoom.Name;
            toRoom.Description = fromRoom.Description;
            if (toRoom.Exits.Any()) { toRoom.Exits.Clear(); }
            if (fromRoom.Exits.Any()) {
                foreach (Exit fromExit in fromRoom.Exits) {
                    Exit toExit = new Exit();
                    toExit.ID = fromExit.ID;
                    toExit.Name = fromExit.Name;
                    toExit.Description = fromExit.Description;
                    toExit.link = fromExit.link;
                    toExit.parent = fromExit.parent;
                    toExit.LinkID = fromExit.LinkID;
                    toRoom.AddExit(toExit);
                }
            }
        }        

    }
}
