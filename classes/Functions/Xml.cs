using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Mountain.classes.collections;
using Mountain.classes.dataobjects;

namespace Mountain.classes.functions {

    public static class Xml {

        //saves class to xml file without namespace
        public static void ObjectToXml(object item, string path) {
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
                Glb.Settings.SystemMessageQueue.Push(e.ToString());
            }
        }

        // returns a string <boolean>true</boolean> if item passed is a boolean set to true, etc
        public static string ObjectToBasicXml(object item) {
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

        public static void ReCreateRegistryAccounts(string path) {
            RegisteredUsers users = new RegisteredUsers();

            Account toetag = new Account(Guid.NewGuid());
            toetag.SetName("Toetag");
            toetag.SetPassword("toetag");
            toetag.Email = "Toetag@thisServer.com";
            toetag.Administrator = true;
            users.List.Add(toetag);

            Account haystack = new Account(Guid.NewGuid());
            haystack.SetName("Haystack");
            haystack.SetPassword("haystack");
            haystack.Email = "haystack@thisServer.com";
            haystack.Administrator = true;
            users.List.Add(haystack);

            Account bucky = new Account(Guid.NewGuid());
            bucky.SetName("Bucky");
            bucky.SetPassword("bucky");
            bucky.Email = "bucky@thisServer.com";
            bucky.Administrator = false;
            users.List.Add(bucky);

            Xml.ObjectToXml(users, path);
        }
        public static void createNode(string Label, string value, XmlTextWriter writer) {
            writer.WriteStartElement(Label);
            writer.WriteString(value);
            writer.WriteEndElement();
        }
        private static void createXml(object sender, EventArgs e) {
            XmlTextWriter writer = new XmlTextWriter("product.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Table");
            createNode("1", "Product 1", "1000", writer);
            createNode("2", "Product 2", "2000", writer);
            createNode("3", "Product 3", "3000", writer);
            createNode("4", "Product 4", "4000", writer);
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
        }

        private static void createNode(string pID, string pName, string pPrice, XmlTextWriter writer) {
            writer.WriteStartElement("Product");
            writer.WriteStartElement("Product_id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_name");
            writer.WriteString(pName);
            writer.WriteEndElement();
            writer.WriteStartElement("Product_price");
            writer.WriteString(pPrice);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
    }
}