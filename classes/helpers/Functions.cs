using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    }
}
