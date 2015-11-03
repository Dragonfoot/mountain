using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    [XmlRoot ("World")]
    public class Users {
        [XmlArray("Players")]
        public List<Account> List { get; set; }
        public Users() {
            List = new List<Account>();
        }
    }

    public class Account {
        private const string passPhrase = "my wee lit^le do_keydunk Duck#y DingdYnglededoo4U";
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Administrator { get; set; }
        public string Email { get; set; }
        public string FileName { get; set; }

        public bool CheckPassword(string inputPassword) {
            if (Password == string.Empty) return false;
            string decryptedPassword = StringCipher.Decrypt(inputPassword, passPhrase);
            return inputPassword.Equals(decryptedPassword);
        }
        public void SetPassword(string newPassword) {
            Password = StringCipher.Encrypt(newPassword, passPhrase);
        }
        public void SetName(string name) {
            Name = name.Camelize();
            if (FileName.IsNullOrWhiteSpace()) {
                FileName = Name + ".xml";
            }
        }
    }
}
