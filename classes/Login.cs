using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public class Login : ClientConnection {

        public Login(TcpClient socket, FormInterface form) : base(socket, form) {
            messageQueue.OnMessageReceived += OnMessageReceived;
            SendWelcome();
            DoLogin();
        }

        private void DoLogin() {
            throw new NotImplementedException();
        }

        private void OnMessageReceived(object myObject) {
            string message = messageQueue.Pop();
            Send("[command] " + message.AddNewLine());
        }
        public void SendWelcome(){
            string welcome = "Welcome to the Mountain Foundation. Please leave your credit card with Harvey at the door.";
            welcome += "We hope you enjoy your stay with us, the food is good, if you like road kill you'll love Sandy's ";
            welcome += "Grill and Sizzle bar. Be prepared for unexpected behaviour from other guests you meet as they ";
            welcome += "have taken a solemn oath to 'compete' to their fullest with everyone. Do help them enjoy their stay as, ";
            welcome += "I'm sure, they will be doing their utmost to see you, um, enjoy yours.";
            Send(welcome.WordWrap(80).Color(true, Ansi.white).AddNewLine());
        }
    }
}
