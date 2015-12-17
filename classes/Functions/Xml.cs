using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Mountain.classes.tcp;
using Mountain.classes.collections;
using Mountain.classes.dataobjects;

namespace Mountain.classes.functions {

    public static class XML {
        
        public static void ObjectToXml(object item, string path) {
            try {
                var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
                var serializer = new XmlSerializer(item.GetType());
                var flags = new XmlWriterSettings() {
                    Indent = true,
                    OmitXmlDeclaration = true
                };
                using (var stream = new StringWriter())
                using (var writer = XmlWriter.Create(stream, flags)) {
                    serializer.Serialize(writer, item, emptyNamepsaces);
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(new StringReader(stream.ToString()));
                    xmlDocument.Save(path);
                }
            } catch (Exception e) {
                Common.Settings.SystemMessageQueue.Push(e.ToString());
            }
        }

        public static string ObjectToBasicXml(object item) {
            var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var serializer = new XmlSerializer(item.GetType());
            var settings = new XmlWriterSettings() {
                Indent = true,
                OmitXmlDeclaration = true
            };
            using (var stream = new StringWriter())
            using (var writer = XmlWriter.Create(stream, settings)) {
                serializer.Serialize(writer, item, emptyNamepsaces);
                return stream.ToString();
            }
        }

        public static void ReCreateRegistryAccounts(string path) {
            RegisteredUsers Registry = new RegisteredUsers();

            Account toetag = new Account() {
                Email = "Toetag@thisServer.com",
                Administrator = true
            };
            toetag.SetName("Toetag");
            toetag.SetPassword("toetag");
            Registry.List.Add(toetag);

            Account haystack = new Account() {
                Email = "haystack@thisServer.com",
                Administrator = true
            };
            haystack.SetName("Haystack");
            haystack.SetPassword("haystack");
            Registry.List.Add(haystack);

            Account bucky = new Account() {
                Email = "bucky@thisServer.com",
                Administrator = false
            };
            bucky.SetName("Bucky");
            bucky.SetPassword("bucky");
            Registry.List.Add(bucky);

            XML.ObjectToXml(Registry, path);
        }

        public static void createNode(string Label, string value, XmlTextWriter writer) {
            writer.WriteStartElement(Label);
            writer.WriteString(value);
            writer.WriteEndElement();
        }        
    }
}