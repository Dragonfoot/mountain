using System.Collections.Concurrent;
using Mountain.classes.dataobjects;

namespace Mountain.classes.collections {

    public class PlayerEventQueue {
        public string Tag { get; set; }
        private ConcurrentQueue<Packet> queue;
        public delegate void EventHandler(object myObject, Packet packet);
        public event EventHandler OnEventReceived;

        public PlayerEventQueue() {
            queue = new ConcurrentQueue<Packet>();
        }

        public void Push(Packet packet) {
            queue.Enqueue(packet);
            OnEventReceived(this, packet);
        }
        public Packet Pop() {
            Packet packet;
            return (queue.TryDequeue(out packet)) ? packet : null;
        }
    }
}
