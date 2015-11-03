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

        public Login(TcpClient socket) : base(socket) {
            messageQueue.OnMessageReceived += OnMessageReceived; // lets get notified when the messageQueue has a new message
            newUser = new Account();
            StartLogin();
        }

        private void StartLogin() {
            Welcome();
            action = login.name; // lets start with getting the name from the user
            string UserNamePrompt = "User Name: ";
            SendIndent(UserNamePrompt.Color(true, Ansi.green));
        }

        protected void OnMessageReceived(object myObject) { // do stuff with the user message
            string message = messageQueue.Pop().Trim();
            string response = string.Empty;
            if (message == null || message == string.Empty || message.Length == 0) return; // oops, lets wait for another
            switch (action) {
                case login.name:
                    if (message.Length < 3 || message.Length > 45) {  // oops, sanity check
                        string usage = "Name length must be from between 3 and 64 characters";
                        Send(usage.NewLine().Color(Ansi.yellow));
                        string UserNamePrompt = "User Name: ";
                        SendIndent(UserNamePrompt.Color(true, Ansi.green)); // re-ask for name
                        return;
                    }
                    switch (checkName(message)) {
                        case userStatus.available: // name is in the user account list
                            Send(message.ToProper().Color(true, Ansi.yellow).NewLine());
                            newUser.SetName(message.ToProper());
                            response = "Password: "; // so lets ask him for his password
                            SendIndent(response.Color(Ansi.green));
                            action = login.password; // channel next incoming message to check for valid password
                            break;
                        case userStatus.nonExistent:  // name doesn't exist, lets ask if its a new account request
                            response = "Create new account: " + message.ToProper() + "?";
                            Send(response.Color(Ansi.yellow).NewLine());
                            action = login.newUser; // channel next incoming for new user answer
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
            string welcome = "Welcome to the Mountain Foundation. ";
            welcome += "The food is good, the drinks even better. If you like road kill you'll love Greggor's infamous ";
            welcome += "Frizzled Sizzle-Griller just off Flatstomp Road near Pancake Hill. ";
            welcome += "Be prepared for unexpected behaviour from our many inhabitants. They ";
            welcome += "have taken solemn oaths to do their very best when meeting you. ";
            Send("".Color(Ansi.clearScreen).NewLine().NewLine());
            Send(welcome.WordWrap(70).Color(true, Ansi.white).NewLine());
        }
        private userStatus checkName(string str) {
            // is name currently logged in, check to see if its lagged out, timed out..
            // is name in userList
            return userStatus.available;
        }
    }
}
