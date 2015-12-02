using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;

namespace Mountain.classes.functions {

    [Serializable] public class Factory {
        public void LoadPlayerFromFile(Connection player, string name, string file) {
            if (!File.Exists(file)) {
                player.Account.Location = new Linkage(Global.Settings.TheVoid.Name, Global.Settings.TheVoid.Location.Area, Global.Settings.TheVoid);
                return;
            } else {
                XmlSerializer serializer = new XmlSerializer(typeof(Connection));
                FileStream fileStream = new FileStream(file, FileMode.Open);
                Connection client = (Connection)serializer.Deserialize(fileStream);
                // get area from client.areaname, get room in area from client.roomname
                player.Account.Location = new Linkage(client.Account.Location.Room.Name, client.Account.Location.Area, client.Account.Location.Room);
                
                if (player.Account.Location.Area == null) {
               //     if (player.Account.RoomID.Name.IsNullOrWhiteSpace()) {
               //         player.Account.RoomID.Name = settings.TheVoid.Name;
                //player.Account.RoomID.ID = settings.TheVoid.ID;
               //     }
         //           player.Account.Location.Area = settings.world.GetAreaNameByRoomName(player.Account.Location.RoomName);
                }
                if (player.Location.Room == null) {
                    Area Area = Global.Settings.world.Areas.First(area => area.Name == player.Account.Location.AreaName);
                    player.Location.Room = (Area.Rooms.FindName(player.Account.Location.RoomName));
                };
                fileStream.Close();
            }
        }
    }
}
