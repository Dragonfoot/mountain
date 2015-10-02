using System;
using System.Collections.Generic;
using System.Xml;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public static class XmlHelper { // helper class to do code friendly xml disk access

        public static string WriteElement(ParamArrayAttribute parameters) {
            return "";
        }
        public static string ElementWithAttribute(string name, ParamArrayAttribute parameters) { 
            return "";
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