using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public enum login { error, start, name, newPlayer, password, done }

    public class Login : ClientConnection {
        protected login action;
        protected User newUser;

        public Login(TcpClient socket, FormInterface form) : base(socket, form) {
            messageQueue.OnMessageReceived += OnMessageReceived;
            newUser = new User();
            StartLogin();
        }

        private void StartLogin() {
            Welcome();
            action = login.name;
            string UserNamePrompt = "User Name: ";
            SendIndent(UserNamePrompt.Color(true, Ansi.green));
        }

        protected void OnMessageReceived(object myObject) {
            string message = messageQueue.Pop();
            if (message == null || message == string.Empty) return;
            switch (action) {
                case login.name:
                    if (message.Length < 3 || message.Length > 64) {
                        string usage = "Name length must be from between 3 and 64 characters";
                        Send(usage.AddNewLine().Color(Ansi.red));
                        string UserNamePrompt = "User Name: ";
                        SendIndent(UserNamePrompt.Color(true, Ansi.green));
                        return;
                    }
                    if (checkName(message)) {
                        Send(message.ToProper().Color(true, Ansi.yellow).AddNewLine());
                        newUser.Name = message.ToProper();
                        string response = "Password: ";
                        SendIndent(response.Color(Ansi.green));
                        action = login.password;
                    } else {
                        string response = "Create new character: " + message.ToProper() + "?";
                        Send(response.Color(Ansi.yellow).AddNewLine());
                        action = login.newPlayer;
                    }
                    break;
                case login.newPlayer:
                    break;
                case login.password:
                    break;
                case login.done:
                    break;
                case login.error:
                    break;
            }
        }

        public void Welcome(){
            string welcome = "Welcome to the Mountain Foundation. ";
            welcome += "The food is good, the drinks even better and if you like road kill you'll love Greggor's famous ";
            welcome += "Fizzle and Sizzle Griller just off Flatout Road near Pancake Drive. ";
            welcome += "Be prepared for unexpected behaviour from our many other guests you meet. They ";
            welcome += "have taken a solemn oath to 'compete' to their fullest with anyone they come across. ";
            welcome += "Please help them enjoy their stay as, ";
            welcome += "I'm sure you'll be finding out, they'll be doing their utmost to see you enjoy yours. ";
            Send(welcome.WordWrap(75).Indent(Global.indent).Color(true, Ansi.white).AddNewLine());
        }
        private bool checkName(string str) {
            return true;
        }
    }
}
