using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class MessageQueue {
        private ConcurrentQueue<string> queue;
        public delegate void MessageHandler(object myObject);
        public event MessageHandler OnMessageReceived;
        public MessageQueue() {
            queue = new ConcurrentQueue<string>();
        }
        public void Push(string msg) {
            queue.Enqueue(msg);
            OnMessageReceived(this);
        }
        public string Pop() {
            string msg;
            bool result;
            result = queue.TryDequeue(out msg);
            return msg;
        }


    }
}
