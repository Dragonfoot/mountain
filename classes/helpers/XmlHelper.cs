﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public static class XmlHelper { 

        public static string WriteElement(ParamArrayAttribute parameters) {
            // test function, will see how ParamArrayAttribute behaves
            return "";
        }

        public static string ElementWithAttribute(string name, ParamArrayAttribute parameters) { 
            //test function
            return "";
        }

        // returns <boolean>true</boolean> if item passed is a boolean set to true, etc
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
    }
}

/* example off the web
 * 
 private XmlElement CreateXmlDoc(string name, int age, string city, string country)
    {
        XmlDocument xDoc = new XmlDocument();
        XmlElement xBatch = xDoc.CreateElement("Batch");
        xBatch.SetAttribute("OnError", "Continue");
        xDoc.AppendChild(xBatch);

        XmlElement method = xDoc.CreateElement("Method");
        method.SetAttribute("ID", "1");
        method.SetAttribute("Cmd", "New");
        xBatch.AppendChild(method);

        method.AppendChild(createFieldElement(xDoc, "Name", name));
        method.AppendChild(createFieldElement(xDoc, "Age", name));
        method.AppendChild(createFieldElement(xDoc, "City", name));
        method.AppendChild(createFieldElement(xDoc, "Country", name));

        return xBatch;
    }

    private XmlElement createFieldElement(XmlDocument doc, string name, string value) 
    {
        XmlElement field = doc.CreateElement("Field");
        field.SetAttribute("Name", name);
        field.Value = value;
        return field;
    }
 */