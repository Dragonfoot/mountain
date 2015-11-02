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
            string[] words = sentence.Split(' ');
            StringBuilder buildLine = new StringBuilder("");
            foreach (var word in words) {
                if (word.Length + buildLine.Length + 1 > width) {
                    lines.Append(buildLine.ToString().Indent(Global.indent).AddNewLine());
                    buildLine.Clear();
                }
                buildLine.Append((buildLine.Length == 0 ? "" : " ") + word);
            }
            if (buildLine.Length > 0) {
                lines.Append(buildLine.ToString().Indent(Global.indent).AddNewLine());
            }
            return lines.ToString();
        }
        public static string Indent(this string str, int size) {
            return str.PadLeft(size);
        }
        public static string ToProper(this string str) {
            TextInfo info = new CultureInfo("en-US", false).TextInfo;
            return info.ToTitleCase(str);
        }
        public static bool IsNumeric(this string value) {
            float result;
            return float.TryParse(value, out result);
        }
        public static bool IsNumberOnly(this string value, bool floatPoint) {
            value = value.Trim();
            if (value.Length == 0)
                return false;
            foreach (char chr in value) {
                if (!char.IsDigit(chr)) {
                    if (floatPoint && (chr == '.'))
                        continue;
                    return false;
                }
            }
            return true;
        }
        public static bool IsNullOrWhiteSpace(this string value) {
            return String.IsNullOrWhiteSpace(value);
        }
        public static string Camelize(this string str) {
            return str.ToProper().Replace(" ", string.Empty);
        }
    }
}
