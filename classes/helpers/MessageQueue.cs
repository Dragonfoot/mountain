using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class MessageQueue {
        private ConcurrentQueue<string> queue;
        public delegate void MessageHandler(object myObject, string msg);
        public event MessageHandler OnMessageReceived;
        public MessageQueue() {
            queue = new ConcurrentQueue<string>();
        }

        public void Push(string message) {
            queue.Enqueue(message);
            OnMessageReceived(this, message);
        }
        public string Pop() {
            string message;
            return (queue.TryDequeue(out message)) ? message : string.Empty;
        }


    }
}
