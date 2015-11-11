using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Mountain.classes.collections;

namespace Mountain.classes.helpers {

    public static class XmlHelper { 
      
        //saves class to xml file without namespace
        public static void ObjectToXml(object item, string path, ApplicationSettings settings) {
            try {
                var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var serializer = new XmlSerializer(item.GetType());
                var flags = new XmlWriterSettings();
                flags.Indent = true;
                flags.OmitXmlDeclaration = true;
                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, flags)) {
                    serializer.Serialize(writer, item, emptyNamepsaces);
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(new StringReader(stream.ToString()));
                    xmlDocument.Save(path);
                }
            } catch (Exception e) {
                settings.SystemMessageQueue.Push(e.ToString());
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
            RegisteredUsers users = new RegisteredUsers();

            Account toetag = new Account(Guid.NewGuid());
            toetag.SetName("Toetag");
            toetag.SetPassword("toetag");
            toetag.Email = "Toetag@thisserver.com";
            toetag.Administrator = true;
            users.List.Add(toetag);

            Account haystack = new Account(Guid.NewGuid());
            haystack.SetName("Haystack");
            haystack.SetPassword("haystack");
            haystack.Email = "haystack@thisserver.com";
            haystack.Administrator = true;
            users.List.Add(haystack);

            Account bucky = new Account(Guid.NewGuid());
            bucky.SetName("Bucky");
            bucky.SetPassword("bucky");
            bucky.Email = "bucky@thisserver.com";
            bucky.Administrator = false;
            users.List.Add(bucky);

            XmlHelper.ObjectToXml(users, path, appSettings);
        }
    }
}