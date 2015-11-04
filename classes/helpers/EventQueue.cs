using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class EventQueue {
        private ConcurrentQueue<Packet> queue;
        public delegate void EventHandler(object myObject);
        public event EventHandler OnEventReceived;

        public EventQueue() {
            queue = new ConcurrentQueue<Packet>();
        }

        public void Push(Packet packet) {
            queue.Enqueue(packet);
            OnEventReceived(this);
        }
        public Packet Pop() {
            Packet packet;
            return (queue.TryDequeue(out packet)) ? packet : new Packet(null);
        }

    }
}
