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

}
