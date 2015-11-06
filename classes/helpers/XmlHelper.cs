using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public static class XmlHelper { 
      
        //saves class to xml file
        public static void ObjectToXml(object item, string path) {
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
        public static void ReCreateDefaultUserXmlFile(string path) {
            Users users = new Users();
            Account adminUser = new Account(Guid.NewGuid());
            adminUser.SetName("Admin");
            adminUser.SetPassword("Admin");
            adminUser.Email = "Admin@com";
            adminUser.FileName = adminUser.Name + ".xml";
            adminUser.Administrator = true;
            users.List.Add(adminUser);
            XmlHelper.ObjectToXml(users, path);
        }
    }
}