using System.Collections.Generic;
using System.Xml.Serialization;
using Mountain.classes.helpers;

namespace Mountain.classes.collections {

    [XmlRoot ("World")]
    public class Users {
        [XmlArray("Players")]
        public List<Account> List { get; set; }
        public Users() {
            List = new List<Account>();
        }
    }
}
/* 
add user
edit user
remove user
backup users
*/