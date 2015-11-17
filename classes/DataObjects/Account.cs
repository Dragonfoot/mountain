using System;
using System.Xml.Serialization;
using Mountain.classes.tcp;
using Mountain.classes.functions;


namespace Mountain.classes.dataobjects {

    public class Account {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Administrator { get; set; }
        public string Email { get; set; }
        [XmlIgnore]
        public Guid ID { get; set; }
        public RoomID RoomID;
        [XmlIgnore]
        public Room Room { get; set; }
        [XmlIgnore]
        public Connection Client { get; set; }

        public Account(Guid id) {
            ID = id;
        }

        public Account() { // empty constructor for de/serialization
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
