using Mountain.classes.functions;

namespace Mountain.classes.dataobjects {

    public class Account {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Administrator { get; set; }
        public string Email { get; set; }

        public Account() {
        }        

        public bool CheckPassword(string inputPassword) {
            if (Password.IsNullOrWhiteSpace()) return false;
            string decryptedPassword = Password.Decrypt();
            return inputPassword.Equals(decryptedPassword);
        }

        public void SetPassword(string newPassword) {
            Password = newPassword.Encrypt();
        }

        public void SetName(string name) {
            Name = name.Camelize();
        }
    }
}
