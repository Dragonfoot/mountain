﻿using System;
using System.Linq;
using System.Collections.Generic;
using Mountain.classes.dataobjects;

namespace Mountain.classes.functions {

    public static class Function {

        public static string ReadableString(Array list) {
            string names = string.Empty; int i = 0;
            foreach (string item in list) {
                names += item;
                if (i != list.Length) { names += ", "; }
                if (i == list.Length) { names += "."; }
                i++;
            }
            return names;
        }

        public static string GetNames(Array list) {
            string names = string.Empty; int i = 1;
            foreach (Identity item in list) {
                names = names + item.Name;
                if (i != list.Length) { names = names + ", "; }
                if (i == list.Length) { names = names + "."; }
                i++;
            }
            return names;
        }

        public static IEnumerable<T> GetValues<T>() {
            return (T[])Enum.GetValues(typeof(T));
        }

        public static int GetSameNameCount(Array list, string name) {
            int i = 0;
            foreach(Identity item in list) {
                if (item.ToString().StartsWith(name, StringComparison.OrdinalIgnoreCase)) { i++; }
            }
            return i;
        }

        public static string GetOtherNames(Array list, string name) {
            string names = string.Empty; int i = 1;
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
            foreach (Identity item in list) {
                string[] names = item.ToString().Split(' ');
                foreach (string word in names) {
                    if (word.StartsWith(name, StringComparison.OrdinalIgnoreCase)) return true;
                }
            }
            return false;
        }

        public static Packet ContainsExit(Array list, Packet packet) {
            foreach(Exit exit in list) {
                if (exit.ToString().WordCount() > 1) {
                    Array words = exit.ToString().Split(' ');
                    foreach (string word in words) {
                        if (word.StartsWith(packet.verb, StringComparison.OrdinalIgnoreCase)) {
                            packet.parameter = exit.ToString();
                            packet.verb = "go";
                            return packet;
                        }
                    }
                } else {
                    if (exit.ToString().StartsWith(packet.verb, StringComparison.OrdinalIgnoreCase)) {
                        packet.parameter = exit.ToString();
                        packet.verb = "go";
                        return packet;
                    }
                }
            }
            return packet;
        }
        
        public static void UpdateRoomEdits(Room fromRoom, Room toRoom) {
            toRoom.Name = fromRoom.Name;
            toRoom.Description = fromRoom.Description;
            if (toRoom.Exits.Any()) { toRoom.Exits.Clear(); }
            if (fromRoom.Exits.Any()) {
                foreach (Exit fromExit in fromRoom.Exits) {
                    Exit toExit = new Exit();
                    toExit.Name = fromExit.Name;
                    toExit.Description = fromExit.Description;
                    toExit.Owner = fromExit.Owner;
                    toExit.Room = fromExit.Room;
                    toExit.Area = fromExit.Area;
                    toRoom.AddExit(toExit);
                }
            }
        }
    }
}
