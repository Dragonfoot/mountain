using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mountain.classes {

    [XmlRoot]
    public class Area : Identity {
        private CancellationTokenSource cancellationTokenSource;
        [XmlArray("Rooms")]
        public List<Room> Rooms { get; private set; }
        [XmlIgnore]
        public bool Active { get; set; }  // in memory or not, conserve resources?

        public Area() {
            Name = "new area";
            Description = "new area";
            Active = true;
            cancellationTokenSource = new CancellationTokenSource();
            Rooms = new List<Room>();
        }

        public Area(string name, string description, Guid id) {
            Name = name;
            Description = description;
            ID = id;
        }

        public void AddRoom(Room room) {
            Rooms.Add(room);
        }

        public void Load(string filename) {
            throw new NotImplementedException("Area Load (filename)");
        }

        public void Load() {
            throw new NotImplementedException("Area Load ()");
        }

        public string ToXml() {
           // string result = base.ToXml(XmlHelper.ObjectToBasicXml(this));
            string result = base.ToXml();
            return result;
           // throw new NotImplementedException("Area Save()");
        }

        public void Save(string filename) {
            throw new NotImplementedException("Area Save(filename)");
        }

        public void StopHeart() {
            cancellationTokenSource.Cancel(); // stop heartbeat
        }

        public void StartHeart() {
            this.cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = this.cancellationTokenSource.Token;
            var task = Task.Factory.StartNew(() => {
                while (true) {
                    cancellationToken.ThrowIfCancellationRequested();
                    foreach (Room room in Rooms) {
                        room.HeartBeat();
                    } 
                    // do schedule checks, 
                    // update time,
                    // other stuff
                }
            }, cancellationToken);
        }
    }

}
