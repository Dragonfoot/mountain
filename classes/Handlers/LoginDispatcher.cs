using System;
using Mountain.classes.dataobjects;
using Mountain.classes.tcp;
using Mountain.classes.functions;

namespace Mountain.classes.handlers {

    public enum login { error, name, newUser, password, newpassword, confirmPassword, raceType, stats }
    public enum userStatus { loggedIn, nonExistent, laggedOut, available}

    [Serializable] public class LoginDispatcher {
        protected login action;
        public Account LoginClient;
        Connection Client;

        public LoginDispatcher(Connection client) {
            Client = client;
            LoginClient = new Account();
        }
        public void Start() {
            Welcome();
            StartLogin();
        }
        private void Welcome() {
            string welcome = "Welcome to the Mountain Foundation. ";
            welcome += "The food is good, the drinks better. If you like road kill you'll love Gregor's ";
            welcome += "Frizzled Sizzle-Griller down by Flatstomp Road near Pancake Hill. ";
            welcome += "Do be prepared for unexpected and mostly friendly behavior from our many inhabitants. They ";
            welcome += "have all taken solemn oaths to do their very utmost for you. Good luck!";
            Client.Send("".Ansi(Style.clearScreen).NewLine().NewLine(), false);
            Client.Send(welcome.WordWrap().Ansi(true, Style.yellow).NewLine(), false);
        }

        private void StartLogin() {
            action = login.name; // start with getting the users player name
            Client.Send("User Name: ".Ansi(true, Style.green));
        }
        public void OnMessageReceived(object myObject, string message) { // do stuff with message
            if (message.IsNullOrWhiteSpace()) {
                Global.Settings.SystemMessageQueue.Push("Login received message is empty");
                return;
            }
            string response = string.Empty;
            switch (action) {
                case login.name:
                    message = message.Camelize();
                    if (message.Length < 3 || message.Length > 45) {  // oops, sanity check
                        Client.Send("Name length must be from 3 to 45 characters long".NewLine().Ansi(Style.yellow), false);
                        StartLogin();
                        break;
                    }
                    switch (checkName(message)) { // someone is returning?
                        case userStatus.available: // we know the name and it isn't currently logged on
                            Client.Send(message.Ansi(true, Style.yellow).NewLine(), false);
                            LoginClient.SetName(message);
                            Client.Send("Password: ".Ansi(Style.green)); // we need a password
                            action = login.password; // channel for validate password
                            break;
                        case userStatus.nonExistent:  // name doesn't exist, ask if its a new account request                        
                            LoginClient.SetName(message);
                            Client.Send("Create new account: ".Ansi(Style.yellow) + message + "  Yes / No ?".Ansi(Style.yellow).NewLine(), false);
                            action = login.newUser; // channel next incoming message
                            break;
                        case userStatus.loggedIn:
                            action = login.name;
                            Client.Send(message + " is currently online.".Ansi(Style.yellow).NewLine().NewLine(), false);
                            StartLogin();
                            break;
                    }
                    break;
                case login.newUser:
                    if (message.IsYes()) {
                        Client.Send("Please enter a password: ".Ansi(Style.green));
                        action = login.newpassword;
                    }
                    else {
                        Client.Send("User Name: ".Ansi(true, Style.green)); // restart login
                        action = login.name;
                    }
                    break;
                case login.password:
                    if (LoginClient.CheckPassword(message)) {
                        Client.Send("".NewLine().NewLine().Ansi(Style.yellow), false);
                        Client.Send("Welcome back ".Ansi(Style.white, Style.white) + LoginClient.Name + "!".NewLine().NewLine());
                        Client.Account = LoginClient;
                        Global.Settings.SwapLoginForPlayer(Client); // swap out login for player handler
                        return;
                    }
                    Client.Send(" Remember, passwords are case sensitive".NewLine().Ansi(Style.yellow), false);
                    StartLogin();
                    break;
                case login.newpassword:
                    // confirm new password
                    break;
                case login.confirmPassword:
                    if (NewUser()) {
                        Client.Account = LoginClient;
                        Global.Settings.SwapLoginForPlayer(Client); // swap out login for player handler
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
            foreach (Account user in Global.Settings.RegisteredUsers) { // find name in list
                if (String.Equals(name, user.Name, StringComparison.OrdinalIgnoreCase)) {
                    LoginClient.Name = user.Name;
                    LoginClient.Password = user.Password;
                    LoginClient.Email = user.Email;
                    LoginClient.Administrator = user.Administrator;
                    LoginClient.ID = user.ID;
                    if (Global.Settings.Players.Exists(user.Name))
                        return userStatus.loggedIn;  // name is already logged in.. timed out?
                    return userStatus.available; // name is registered user
                }
            }
            return userStatus.nonExistent; // make new user?
        }
    }
}
