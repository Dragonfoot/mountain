using System;
using System.Collections.Generic;

namespace Mountain.classes.helpers {

    public enum Ansi { reset, bold, italic, ul, boldOff, italicOff, ulOff, black, red, green, yellow, blue, magenta, cyan, 
                            white, blackBk, redBk, greenBK, yellowBk, blueBk, magentaBk, cyanBk, whiteBk };

    public static class Colors {
        private readonly static List<string> table = new List<string>();

        static Colors() {   // change this to an array or list of strings
            table.Add("\x1B[0m");     // reset
            // Style Modifiers (on)
            table.Add("\x1B[1m");      // bold
            table.Add("\x1B[3m");      // italic
            table.Add("\x1B[4m");     // underline
            // Style Modifiers (off)
            table.Add("\x1B[22m");     // stop bold
            table.Add("\x1B[23m");     // stop italic
            table.Add("\x1B[24m");     // not underline
            // Foreground
            table.Add("\x1B[30m");     // black
            table.Add("\x1B[31m");     // red
            table.Add("\x1B[32m");     // green
            table.Add("\x1B[33m");     // yellow      
            table.Add("\x1B[34m");     // blue
            table.Add("\x1B[35m");     // magenta
            table.Add("\x1B[36m");     // cyan
            table.Add("\x1B[37m");     // white
            // Background
            table.Add("\x1B[40m");     // black bg
            table.Add("\x1B[41m");     // red bg
            table.Add("\x1B[42m");     // green bg
            table.Add("\x1B[43m");     // yellow bg
            table.Add("\x1B[44m");     // blue bg
            table.Add("\x1B[45m");     // magenta bg
            table.Add("\x1B[46m");     // cyan bg
            table.Add("\x1B[47m");    // white bg
        }
        // no bold, returns string in passed color then resets color to default
        public static string Color(this string str, Ansi index, Ansi reset) { 
            return table[(int)index] + str + table[(int)reset];
        }
        // allows for bold or no bold to be added to basic color and reset function 
        public static string Color(this string str, bool bold, Ansi index, Ansi reset) {
            string prefix = (bold) ? table[(int)Ansi.bold] : table[(int)Ansi.boldOff];
            return prefix + str.Color(index, reset);
        }
        // allows for bold or no bold, sets the string color, does not reset color
        public static string Color(this string str, bool bold, Ansi index) {
            string prefix = (bold) ? table[(int)Ansi.bold] : table[(int)Ansi.boldOff];
            return prefix + table[(int)index] + str;
        }
        // sets string to bold and color only
        public static string Color(this string str, Ansi index) {
            return str.Color(true, index);
        }
    }
}
