using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;

namespace Mountain.classes.functions {

    [Serializable]
    public class FCT {
        public void LoadPlayerFromFile(Connection player, string name, string file) {
            player.Room = GBL.Settings.TheVoid;
            return;
            /*   if (!File.Exists(file)) {
                   player.Account.Location = new Location(Glb.Settings.TheVoid);
                   return;
               } else {
                   XmlSerializer serializer = new XmlSerializer(typeof(Connection));
                   FileStream fileStream = new FileStream(file, FileMode.Open);
                   Connection client = (Connection)serializer.Deserialize(fileStream);
                   // get area from client.areaname, get room in area from client.roomname
                   if (client.Account.Location.Room == null) client.Account.Location.Room = Glb.Settings.TheVoid;
                   player.Account.Location = new Location(client.Account.Location.Room);

                   if (player.Account.Location.Area == null) {
                  //     if (player.Account.RoomID.Name.IsNullOrWhiteSpace()) {
                  //         player.Account.RoomID.Name = settings.TheVoid.Name;
                   //player.Account.RoomID.ID = settings.TheVoid.ID;
                  //     }
            //           player.Account.Location.Area = settings.world.GetAreaNameByRoomName(player.Account.Location.RoomName);
                   }
                   if (player.Location == null) {
                       player.Location = player.Account.Location;
                   }
                   if (player.Location.Room == null) {
                       Area Area = Glb.Settings.World.Areas.First(area => area.Name == player.Account.Location.AreaName);
                       player.Location.Room = (Area.Rooms.FindName(player.Account.Location.RoomName));
                   };
                   fileStream.Close();
               }*/
        }
    }
}
