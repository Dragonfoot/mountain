using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public static class XmlHelper { 
      
        //saves class to xml file
        public static void ObjectToXml(object item, string path, ApplicationSettings settngs) {
            try {
                var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var serializer = new XmlSerializer(item.GetType());
                var settings = new XmlWriterSettings();
                settings.Indent = true;
                settings.OmitXmlDeclaration = true;
                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, settings)) {
                    serializer.Serialize(writer, item, emptyNamepsaces);
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(new StringReader(stream.ToString()));
                    xmlDocument.Save(path);
                }
            } catch (Exception e) {
                settngs.SystemMessageQueue.Push(e.ToString());
            }
        }

        // returns a string <boolean>true</boolean> if item passed is a boolean set to true, etc
        public static string PrimaryXml(object item) {  
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(item.GetType());
            var settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings)) {
                serializer.Serialize(writer, item, emptyNamepsaces);
                return stream.ToString();
            }
        }

        public static void ReCreateDefaultUserXmlFile(string path, ApplicationSettings appSettings) {
            Users users = new Users();
            Account adminUser = new Account(Guid.NewGuid());
            adminUser.SetName("Admin");
            adminUser.SetPassword("Admin");
            adminUser.Email = "Admin@thisserver.com";
            adminUser.FileName = adminUser.Name + ".xml";
            adminUser.Administrator = true;
            users.List.Add(adminUser);

            Account toetag = new Account(Guid.NewGuid());
            toetag.SetName("Toetag");
            toetag.SetPassword("Toetag");
            toetag.Email = "Toetag@thisserver.com";
            toetag.FileName = toetag.Name + ".xml";
            toetag.Administrator = true;
            users.List.Add(toetag);

            Account haystack = new Account(Guid.NewGuid());
            haystack.SetName("Haystack");
            haystack.SetPassword("haystack");
            haystack.Email = "haystack@thisserver.com";
            haystack.FileName = haystack.Name + ".xml";
            haystack.Administrator = true;
            users.List.Add(haystack);

            XmlHelper.ObjectToXml(users, path, appSettings);
        }
    }
}