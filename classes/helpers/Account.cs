using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public class Account {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Administrator { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }
        [XmlIgnore]
        public Guid ID { get; set; }
        public RoomID RoomID;
        public Room Room { get; set; }

        public Account(Guid id) {
            ID = id;
        }
        public Account() {
        }

        public bool CheckPassword(string inputPassword) {
            if (Password.IsNullOrWhiteSpace()) return false;
            string decryptedPassword = StringCipher.Decrypt(Password);
            return inputPassword.Equals(decryptedPassword);
        }
        public void SetPassword(string newPassword) {
            Password = StringCipher.Encrypt(newPassword);
        }
        public void SetName(string name) {
            Name = name.Camelize();
            if (FileName.IsNullOrWhiteSpace()) {
                FileName = Name + ".xml";
            }
        }
    }
}
