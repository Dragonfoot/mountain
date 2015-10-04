using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public enum ColorCode { reset, bold, italic, ul, inverse, strike, boldOff, italicOff, ulOff, inverseOff, strikeOff, 
                black, red, green, yellow, blue, magenta, cyan, white, blackBk, redBk, greenBK, yellowBk, blueBk, magentaBk, cyanBk, whiteBk };

    class Colors {
        private static List<Color> table = new List<Color>();

        static Colors() {
            table.Add(new Color("{reset}", "\x1B[0m"));
            // Style Modifiers (on)
            table.Add(new Color("{bold}", "\x1B[1m"));
            table.Add(new Color("{italic}", "\x1B[3m"));
            table.Add(new Color("{ul}", "\x1B[4m"));
            table.Add(new Color("{inverse}", "\x1B[7m"));
            table.Add(new Color("{strike}", "\x1B[9m"));
            // Style Modifiers (off)
            table.Add(new Color("{!bold}", "\x1B[22m"));
            table.Add(new Color("{!italic}", "\x1B[23m"));
            table.Add(new Color("{!ul}", "\x1B[24m"));
            table.Add(new Color("{!inverse}", "\x1B[27m"));
            table.Add(new Color("{!strike}", "\x1B[29m"));
            // Foreground
            table.Add(new Color("{black}", "\x1B[30m"));
            table.Add(new Color("{red}", "\x1B[31m"));
            table.Add(new Color("{green}", "\x1B[32m"));
            table.Add(new Color("{yellow}", "\x1B[33m"));
            table.Add(new Color("{blue}", "\x1B[34m"));
            table.Add(new Color("{magenta}", "\x1B[35m"));
            table.Add(new Color("{cyan}", "\x1B[36m"));
            table.Add(new Color("{white}", "\x1B[37m"));
            // Background
            table.Add(new Color("{!black}", "\x1B[40m"));
            table.Add(new Color("{!red}", "\x1B[41m"));
            table.Add(new Color("{!green}", "\x1B[42m"));
            table.Add(new Color("{!yellow}", "\x1B[43m"));
            table.Add(new Color("{!blue}", "\x1B[44m"));
            table.Add(new Color("{!magenta}", "\x1B[45m"));
            table.Add(new Color("{!cyan}", "\x1B[46m"));
            table.Add(new Color("{!white}", "\x1B[47m"));
        }
        public static string Colorize(string stringToColor) { // test with multiple {colorCodes} imbedded in string
            foreach (Color color in table) {
                stringToColor = stringToColor.Replace(color.Tag, color.Ansi);
            }
            return (stringToColor);
        }
    }
    struct Color {
             
        string tag;
        string ansi;

        public string Ansi {
            get { return ansi; }
        } // End of ReadOnly Code

        public string Tag {
            get { return tag; }
        } // End of ReadOnly Identifier


        public Color(string tag, string ansi) {
            // Set our values
            this.tag = tag;
            this.ansi = ansi;
        }
    }
}
