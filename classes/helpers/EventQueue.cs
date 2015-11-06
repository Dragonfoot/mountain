using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class EventQueue {
        private ConcurrentQueue<EventPacket> queue;
        public delegate void EventHandler(object myObject);
        public event EventHandler OnEventReceived;

        public EventQueue() {
            queue = new ConcurrentQueue<EventPacket>();
        }

        public void Push(EventPacket packet) {
            queue.Enqueue(packet);
            OnEventReceived(this);
        }
        public EventPacket Pop() {
            EventPacket packet;
            return (queue.TryDequeue(out packet)) ? packet : new EventPacket();
        }

    }
}
