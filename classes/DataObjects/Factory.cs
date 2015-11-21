using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Serialization;
using Mountain.classes.functions;
using Mountain.classes.tcp;
namespace Mountain.classes.dataobjects {

    public class Factory {

        public void LoadPlayerFromFile(Connection player, string name, string file, ApplicationSettings settings) {
            if (!File.Exists(file)) {
                player.Account.RoomID.Area = settings.TheVoid.RoomID.Area;
                player.Account.RoomID.Name = settings.TheVoid.RoomID.Name;
                player.Account.RoomID.ID = settings.TheVoid.RoomID.ID;
                player.Room = settings.TheVoid;
                return;
            } else {
                XmlSerializer serializer = new XmlSerializer(typeof(Connection));
                FileStream fileStream = new FileStream(file, FileMode.Open);
                Connection client = (Connection)serializer.Deserialize(fileStream);
                player.Account.RoomID.Area = client.Account.RoomID.Area;
                player.Account.RoomID.Name = client.Account.RoomID.Name;
                player.Account.RoomID.ID = client.Account.RoomID.ID;
                if (player.Account.RoomID.Area.IsNullOrWhiteSpace()) {
                    if (player.Account.RoomID.Name.IsNullOrWhiteSpace()) {
                        player.Account.RoomID.Name = settings.TheVoid.Name;
                        player.Account.RoomID.ID = settings.TheVoid.ID;
                    }
                    player.Account.RoomID.Area = settings.world.GetAreaNameByRoomName(player.Account.RoomID.Name);
                }
                if (player.Room == null) {
                    Area Area = settings.world.Areas.First(area => area.Name == player.Account.RoomID.Area);
                    player.Room = (Area.Rooms.FindName(player.Account.RoomID.Name));
                };
            }
        }
    }
}
