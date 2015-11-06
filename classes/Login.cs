using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.classes.helpers;

namespace Mountain.classes {

    public enum login { error, name, newUser, password, newpassword, done }
    public enum userStatus { loggedIn, nonExistent, laggedOut, available }

    public class Login : ClientConnection {
        private bool indent;
        private bool noIndent;
        protected login action;
        protected Account newUser;
        protected ApplicationSettings settings;
        public new Guid ID { get; set; }

        public Login(TcpClient socket, ApplicationSettings appSettings)
            : base(socket) {
            indent = true;
            noIndent = false;
            messageQueue.OnMessageReceived += OnMessageReceived; // get notified when the messageQueue has a new one
            ID = Guid.NewGuid();
            newUser = new Account(ID);
            settings = appSettings;
            Welcome();
            StartLogin();
        }

        private void Welcome() {
            string welcome = "Welcome to the Mountain Foundation. ";
            welcome += "The food is good, the drinks even better. If you like road kill you'll love Greggor's infamous ";
            welcome += "Frizzled Sizzle-Griller just off Flatstomp Road near Pancake Hill. ";
            welcome += "Be prepared for unexpected behaviour from our many inhabitants. They ";
            welcome += "have taken solemn oaths to do their very best when meeting you. Good luck!";
            Send("".Color(Ansi.clearScreen).NewLine().NewLine(), noIndent);
            Send(welcome.WordWrap(65).Color(true, Ansi.yellow).NewLine(), noIndent);
        }

        private void StartLogin() {
            action = login.name; // start with getting the users player name
            Send("User Name: ".Color(true, Ansi.green), indent);
        }

        protected void OnMessageReceived(object myObject, string msg) { // do stuff with incoming user message
            string message = messageQueue.Pop().Trim(); // pull the message
            if (message.IsNullOrWhiteSpace()) message = msg;
            string response = string.Empty;
            if (message.IsNullOrWhiteSpace()) return; // oops, lets have this thread wait for another message
            switch (action) {
                case login.name:
                    message = message.Camelize();
                    if (message.Length < 3 || message.Length > 45) {  // oops, sanity check
                        Send("Name length must be from 3 to 45 characters long".NewLine().Color(Ansi.yellow), noIndent);
                        StartLogin();
                        break;
                    }
                    switch (checkName(message)) { // someone is returning?
                        case userStatus.available: // we know the name and it isn't currently logged on
                            Send(message.Color(true, Ansi.yellow).NewLine(), noIndent);
                            newUser.SetName(message);
                            Send("Password: ".Color(Ansi.green), indent); // we need a password
                            action = login.password; // channel next incoming message to validate password
                            break;
                        case userStatus.nonExistent:  // name doesn't exist, lets ask if its a new account request                        
                            newUser.SetName(message);
                            Send("Create new account: ".Color(Ansi.yellow) + message + "  Yes / No ?".Color(Ansi.yellow).NewLine(), noIndent);
                            action = login.newUser; // channel next incoming message for new user's answer response
                            break;
                    }
                    break;
                case login.newUser:
                    if (message.IsYes()) {
                        Send("Please enter a password: ".Color(Ansi.green), indent);
                        action = login.newpassword;
                    } else {
                        Send("User Name: ".Color(true, Ansi.green), indent); // restart login
                        action = login.name;
                    }
                    break;
                case login.password:
                    if (newUser.CheckPassword(message)) {
                        messageQueue.OnMessageReceived -= OnMessageReceived; // stop processing input for here
                        Send(":)".NewLine().NewLine().Color(Ansi.yellow), noIndent);
                        Send("Welcome back ".Color(Ansi.white, Ansi.white) + newUser.Name + "!".NewLine(), indent);
                        settings.ConvertLoginToPlayer(newUser); // start processing input with player class
                        return;
                    }
                    Send(" Remember, passwords are case sensitive".NewLine().Color(Ansi.yellow), noIndent);
                    StartLogin();
                    break;
                case login.newpassword:
                    break;
                case login.done:
                    break;
                case login.error:
                    break;
            }
        }

        private userStatus checkName(string str) {
            foreach (Account user in settings.RegisteredUsers) { // is name in our userList
                if (String.Equals(str, user.Name, StringComparison.OrdinalIgnoreCase)) {
                    newUser.Name = user.Name;
                    newUser.Password = user.Password;
                    newUser.Email = user.Email;
                    newUser.FileName = user.FileName;
                    newUser.Administrator = user.Administrator;
                    return userStatus.available; // also check if name is already logged in and/or lagged out
                }
            }
            return userStatus.nonExistent; // requesting new user?
        }


    } // end class
 

}
