using System;
using System.Collections.Generic;

namespace Mountain.classes.helpers {

    public enum Ansi { reset, bold, italic, ul, boldOff, italicOff, ulOff, black, red, green, yellow, blue, magenta, cyan, 
                            white, blackBk, redBk, greenBK, yellowBk, blueBk, magentaBk, cyanBk, whiteBk };

    public static class Colors {
        private static List<string> colorTable = new List<string>();

        static Colors() {   // change this to an array or list of strings
            colorTable.Add("\x1B[0m");     // reset
            // Style Modifiers (on)
            colorTable.Add("\x1B[1m");      // bold
            colorTable.Add("\x1B[3m");      // italic
            colorTable.Add("\x1B[4m");     // underline
            // Style Modifiers (off)
            colorTable.Add("\x1B[22m");     // stop bold
            colorTable.Add("\x1B[23m");     // stop italic
            colorTable.Add("\x1B[24m");     // not underline
            // Foreground
            colorTable.Add("\x1B[30m");     // black
            colorTable.Add("\x1B[31m");     // red
            colorTable.Add("\x1B[32m");     // green
            colorTable.Add("\x1B[33m");     // yellow      
            colorTable.Add("\x1B[34m");     // blue
            colorTable.Add("\x1B[35m");     // magenta
            colorTable.Add("\x1B[36m");     // cyan
            colorTable.Add("\x1B[37m");     // white
            // Background
            colorTable.Add("\x1B[40m");     // black bg
            colorTable.Add("\x1B[41m");     // red bg
            colorTable.Add("\x1B[42m");     // green bg
            colorTable.Add("\x1B[43m");     // yellow bg
            colorTable.Add("\x1B[44m");     // blue bg
            colorTable.Add("\x1B[45m");     // magenta bg
            colorTable.Add("\x1B[46m");     // cyan bg
            colorTable.Add("\x1B[47m");    // white bg
        }
        public static string Color(Ansi index, string text) { 
            return colorTable[(int)index] + text + colorTable[0];
        }
        public static string Color(this string str, Ansi index) {
            return colorTable[(int)index] + str;
        }
    }
}
