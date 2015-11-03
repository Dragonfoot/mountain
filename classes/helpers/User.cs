using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mountain.Properties;

namespace Mountain.classes.helpers {

    public class User {
        private const string passPhrase = "my wee lit^le do_keydunk Duck#y DingdYnglededoo4U";
        public string Name { get; set; }
        public string Password { get; set; }
        public List<string> Worlds { get; set; }
        public string FileName { get; set; }
        public string Email { get; set; }

        public User() {
            Worlds = new List<string>();
        }

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
            FileName = Name + ".xml";
        }
        public void AddWorld(string world) {
            Worlds.Add(world);
        }

        
    }

   
}
