using System;
using System.Collections.Generic;

/* ansi color code references   
 http://pueblo.sourceforge.net/doc/manual/ansi_color_codes.html 
 * http://ascii-table.com/ansi-escape-sequences.php
 */
namespace Mountain.classes.helpers {

    public enum Ansi { reset, bold, dim, italic, ul, boldOff, italicOff, ulOff, black, red, green, yellow, blue, magenta, cyan, 
                            white, blackBk, redBk, greenBK, yellowBk, blueBk, magentaBk, cyanBk, whiteBk, clearScreen };
    
    public static class Colors {
        private readonly static List<string> table = new List<string>();
        public const string Esc = "\x1B[";

        static Colors() {
            table.Add(Esc + "0m");      // reset
            // Style Modifiers (on)
            table.Add(Esc + "1m");      // bold
            table.Add(Esc + "2m");      // dim
            table.Add(Esc + "3m");      // italic
            table.Add(Esc + "4m");      // underline
            // Style Modifiers (off)
            table.Add(Esc + "22m");     // stop bold
            table.Add(Esc + "23m");     // stop italic
            table.Add(Esc + "24m");     // not underline
            // Foreground
            table.Add(Esc + "30m");     // black
            table.Add(Esc + "31m");     // red
            table.Add(Esc + "32m");     // green
            table.Add(Esc + "33m");     // yellow      
            table.Add(Esc + "34m");     // blue
            table.Add(Esc + "35m");     // magenta
            table.Add(Esc + "36m");     // cyan
            table.Add(Esc + "37m");     // white
            // Background
            table.Add(Esc + "40m");     // black bg
            table.Add(Esc + "41m");     // red bg
            table.Add(Esc + "42m");     // green bg
            table.Add(Esc + "43m");     // yellow bg
            table.Add(Esc + "44m");     // blue bg
            table.Add(Esc + "45m");     // magenta bg
            table.Add(Esc + "46m");     // cyan bg
            table.Add(Esc + "47m");     // white bg
            // screen
            table.Add(Esc + "2J");      // clear screen
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
            string result = prefix + table[(int)index] + str;
            return result;
        }
        // sets string to bold and color only
        public static string Color(this string str, Ansi index) {
            return str.Color(true, index);
        }
    }
}
