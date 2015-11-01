using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public static class Functions {

        public static string GetNames(Array list) {
            string names = string.Empty;
            int i = 1;
            foreach (Identity item in list) {
                names = names + item.Name;
                if (i != list.Length) {
                    names = names + ", ";
                }
                if (i == list.Length) {
                    names = names + ".";
                }
                i++;
            }
            return names;
        }

        public static string StripNewLine(this string str) {
            return Regex.Replace(str, @"\t|\n|\r", "");
        }
        public static string AddNewLine(this string str) {
            return str + Environment.NewLine;
        }

        public static string WordWrap(this string sentence, int width) {
            StringBuilder lines = new StringBuilder();
            string[] pieces = sentence.Split(' ');
            StringBuilder tempString = new StringBuilder("");
            foreach (var piece in pieces) {
                if (piece.Length + tempString.Length + 1 > width) {
                    lines.Append(tempString.ToString().Indent(Global.indent).AddNewLine());
                    tempString.Clear();
                }
                tempString.Append((tempString.Length == 0 ? "" : " ") + piece);
            }
            if (tempString.Length > 0) {
                lines.Append(tempString.ToString().Indent(Global.indent).AddNewLine());
            }
            return lines.ToString();
        }

        public static string Indent(this string str, int size) {
            string spaces = "";
            for (int i = 0; i <= size; i++) {
                spaces = spaces + " ";
            }
            return spaces + str;
        }
        public static string ToProper(this string str) {
            TextInfo ti = new CultureInfo("en-US", false).TextInfo;
            return ti.ToTitleCase(str);
        }
    }
}
