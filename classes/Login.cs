using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public enum login { error, start, name, newUser, password, done }
    public enum userStatus { loggedIn, nonExistent, laggedOut, available } 

    public class Login : ClientConnection {
        protected login action;
        protected Account newUser;

        public Login(TcpClient socket, FormInterface form) : base(socket, form) {
            messageQueue.OnMessageReceived += OnMessageReceived;
            newUser = new Account();
            StartLogin();
        }

        private void StartLogin() {
            Welcome();
            action = login.name;
            string UserNamePrompt = "User Name: ";
            SendIndent(UserNamePrompt.Color(true, Ansi.green));
        }

        protected void OnMessageReceived(object myObject) {
            string message = messageQueue.Pop().Trim();
            string response = string.Empty;
            if (message == null || message == string.Empty || message.Length == 0) return;
            switch (action) {
                case login.name:
                    if (message.Length < 3 || message.Length > 64) {
                        string usage = "Name length must be from between 3 and 64 characters";
                        Send(usage.AddNewLine().Color(Ansi.red));
                        string UserNamePrompt = "User Name: ";
                        SendIndent(UserNamePrompt.Color(true, Ansi.green));
                        return;
                    }
                    switch (checkName(message)) {
                        case userStatus.available:
                            Send(message.ToProper().Color(true, Ansi.yellow).AddNewLine());
                            newUser.SetName(message.ToProper());
                            response = "Password: ";
                            SendIndent(response.Color(Ansi.green));
                            action = login.password;
                            break;
                        case userStatus.nonExistent:
                            response = "Create new account: " + message.ToProper() + "?";
                            Send(response.Color(Ansi.yellow).AddNewLine());
                            action = login.newUser;
                            break;
                    }
                    break;
                case login.newUser:
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
            string clearScreen = "";
            string welcome = "Welcome to the Mountain Foundation. ";
            welcome += "The food is good, the drinks even better. If you like road kill you'll love Greggor's infamous ";
            welcome += "Frizzled Sizzle-Griller just off Flatstomp Road near Pancake Hill. ";
            welcome += "Be prepared for unexpected behaviour from our many other guests. They ";
            welcome += "have taken solemn oaths to do their best for you. ";
            welcome += "Please help them enjoy their stay, as, ";
            welcome += "I'm sure you'll find out, they'll be doing their utmost to see you do. ";
            Send(clearScreen.Color(Ansi.clearScreen).AddNewLine().AddNewLine());
            Send(welcome.WordWrap(75).Color(true, Ansi.white).AddNewLine());
        }
        private userStatus checkName(string str) {
            // is name currently logged in, check to see if its lagged out, timed out..
            // is name in userList
            return userStatus.available;
        }
    }
}
