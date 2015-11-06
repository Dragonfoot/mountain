using System;
using System.Xml;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using Mountain.classes.helpers;
using Mountain.classes.Items;

namespace Mountain.classes {

    public delegate void CommandDelegate(string message);

    public class Administrator : Player {

        public Administrator(TcpClient socket, Account user)
            : base(socket, user) {
            ClassType = classType.player; 
            UserAccount = user;
            Nick = user.Name;
            Name = user.Name;
            messageQueue.OnMessageReceived += AdminOnMessageReceived; 
            Inventory = new ConcurrentBag<Item>();
            EnemyPlayers = new ConcurrentBag<Player>();
            EnemyMobs = new ConcurrentBag<Mob>();
            Equipment = new Equipment();
            Stats = new Stats();
            Send("Ready ".Color(Ansi.white).NewLine(), true);
        }

        private void AdminOnMessageReceived(object myObject, string msg) {
            //check for admin stuff, if not then pass it down the chain
            base.OnPlayerMessageReceived(myObject, msg);
        }
       
    }
}
