using System;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;

namespace Mountain.classes.handlers {

    public enum login { error, name, newUser, password, newpassword, confirmPassword, raceType, stats }
    public enum userStatus { loggedIn, nonExistent, laggedOut, available}

    public class LoginHandler {
        protected login action;
        public Account LoginClient;
        Connection Client;
        ApplicationSettings settings;

        public LoginHandler(Connection client, ApplicationSettings appSettings) {
            Client = client;
            settings = appSettings;
            LoginClient = new Account();
        }
        public void Start() {
            Welcome();
        }
        private void Welcome() {
            string welcome = "Welcome to the Mountain Foundation. ";
            welcome += "The food is good, the drinks better. If you like road kill you'll love Greggor's ";
            welcome += "Frizzled Sizzle-Griller down by Flatstomp Road near Pancake Hill. ";
            welcome += "Do be prepared for unexpected and mostly friendly behaviour from our many inhabitants. They ";
            welcome += "have all taken solemn oaths to do their very utmost for you. Good luck!";
            Client.Send("".Color(Ansi.clearScreen).NewLine().NewLine(), false);
            Client.Send(welcome.WordWrap(65).Color(true, Ansi.yellow).NewLine(), false);
            StartLogin();
        }

        private void StartLogin() {
            action = login.name; // start with getting the users player name
            Client.Send("User Name: ".Color(true, Ansi.green), true);
        }
        public void OnMessageReceived(object myObject, string message) { // do stuff with message
            if (message.IsNullOrWhiteSpace()) {
                Client.settings.SystemMessageQueue.Push("Login received message is empty");
                return;
            }
            string response = string.Empty;
            switch (action) {
                case login.name:
                    message = message.Camelize();
                    if (message.Length < 3 || message.Length > 45) {  // oops, sanity check
                        Client.Send("Name length must be from 3 to 45 characters long".NewLine().Color(Ansi.yellow), false);
                        StartLogin();
                        break;
                    }
                    switch (checkName(message)) { // someone is returning?
                        case userStatus.available: // we know the name and it isn't currently logged on
                            Client.Send(message.Color(true, Ansi.yellow).NewLine(), false);
                            LoginClient.SetName(message);
                            Client.Send("Password: ".Color(Ansi.green), true); // we need a password
                            action = login.password; // channel for validate password
                            break;
                        case userStatus.nonExistent:  // name doesn't exist, ask if its a new account request                        
                            LoginClient.SetName(message);
                            Client.Send("Create new account: ".Color(Ansi.yellow) + message + "  Yes / No ?".Color(Ansi.yellow).NewLine(), false);
                            action = login.newUser; // channel next incoming message
                            break;
                        case userStatus.loggedIn:
                            action = login.name;
                            Client.Send(message + " is currently online.".Color(Ansi.yellow).NewLine().NewLine(), false);
                            StartLogin();
                            break;
                    }
                    break;
                case login.newUser:
                    if (message.IsYes()) {
                        Client.Send("Please enter a password: ".Color(Ansi.green), true);
                        action = login.newpassword;
                    }
                    else {
                        Client.Send("User Name: ".Color(true, Ansi.green), true); // restart login
                        action = login.name;
                    }
                    break;
                case login.password:
                    if (LoginClient.CheckPassword(message)) {
                        Client.Send("".NewLine().NewLine().Color(Ansi.yellow), false);
                        Client.Send("Welcome back ".Color(Ansi.white, Ansi.white) + LoginClient.Name + "!".NewLine(), true);
                        Client.Account = LoginClient;
                        Client.settings.SwapLoginForPlayer(Client); // swap out login for player handler
                        return;
                    }
                    Client.Send(" Remember, passwords are case sensitive".NewLine().Color(Ansi.yellow), false);
                    StartLogin();
                    break;
                case login.newpassword:
                    // confirm new password
                    break;
                case login.confirmPassword:
                    if (NewUser()) {
                        Client.Account = LoginClient;
                        Client.settings.SwapLoginForPlayer(Client); // swap out login for player handler
                        return;
                    }
                    break;
                case login.raceType:
                    break;
                case login.stats:
                    break;
                case login.error:
                    break;
            }
        }

        private bool NewUser() {
            return false;
        }

        private userStatus checkName(string name) {
            foreach (Account user in Client.settings.RegisteredUsers) { // find name in list
                if (String.Equals(name, user.Name, StringComparison.OrdinalIgnoreCase)) {
                    LoginClient.Name = user.Name;
                    LoginClient.Password = user.Password;
                    LoginClient.Email = user.Email;
                    LoginClient.Administrator = user.Administrator;
                    if (settings.Players.Exists(user.Name))
                        return userStatus.loggedIn;  // name is already logged in.. timed out?
                    return userStatus.available; // name is registered user
                }
            }
            return userStatus.nonExistent; // make new user?
        }
    }
}
