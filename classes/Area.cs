using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace Mountain.classes {

    public class Area : Identity {
        private CancellationTokenSource cancellationTokenSource;
        public ConcurrentBag<Room> Rooms { get; private set; }
        public bool Active { get; set; }

        public Area() {
            Name = "new area";
            Description = "new area";
            cancellationTokenSource = new CancellationTokenSource();
            Rooms = new ConcurrentBag<Room>();
        }
        public Area(string name, string description, Guid id) {
            Name = name;
            Description = description;
            ID = id;
        }


        public void Load() {
            throw new NotImplementedException("Area Load");
        }
        public void Save() {
            throw new NotImplementedException("Area Save");
        }

        public void Close() {
            cancellationTokenSource.Cancel(); // stop heartbeat
        }


        public void StartHeartBeat() {
            this.cancellationTokenSource = new CancellationTokenSource();
            var cancellationToken = this.cancellationTokenSource.Token;
            var task = Task.Factory.StartNew(() => {
                while (true) {
                    cancellationToken.ThrowIfCancellationRequested();
                    foreach (Room room in Rooms) {
                        room.Beat();
                    } 
                    // do schedule checks, 
                    // update time,
                    // other stuff
                }
            }, cancellationToken);
        }
    }
}
