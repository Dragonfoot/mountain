﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DemoProject
{
    class AnsiColor
    {
        #region Private Varaibles

        // Create our color table
        private static List <ColorData> colorTable = new List <ColorData> ( );

        #endregion

        #region Constructor

        /// <summary>
        /// static constructor used to prefill color table
        /// </summary>
        static AnsiColor ( )
        {
            // Our reset values turns everything to the default mode
            colorTable.Add ( new ColorData ( "{reset}",    "\x1B[0m", "Reset" ) );

            // Style Modifiers (on)
            colorTable.Add ( new ColorData ( "{bold}",      "\x1B[1m", "Bold" ) );
            colorTable.Add ( new ColorData ( "{italic}",    "\x1B[3m", "Italic" ) );
            colorTable.Add ( new ColorData ( "{ul}",        "\x1B[4m", "Underline" ) );
            colorTable.Add ( new ColorData ( "{blink}",     "\x1B[5m", "Blink" ) );
            colorTable.Add ( new ColorData ( "{blinkf}",    "\x1B[6m", "Blink Fast" ) );
            colorTable.Add ( new ColorData ( "{inverse}",   "\x1B[7m", "Inverse" ) );
            colorTable.Add ( new ColorData ( "{strike}",    "\x1B[9m", "Strikethrough" ) );

            // Style Modifiers (off)
            colorTable.Add ( new ColorData ( "{!bold}",     "\x1B[22m", "Bold Off" ) );
            colorTable.Add ( new ColorData ( "{!italic}",   "\x1B[23m", "Italic Off" ) );
            colorTable.Add ( new ColorData ( "{!ul}",       "\x1B[24m", "Underline Off" ) );
            colorTable.Add ( new ColorData ( "{!blink}",    "\x1B[25m", "Blink Off" ) );
            colorTable.Add ( new ColorData ( "{!inverse}",  "\x1B[27m", "Inverse Off" ) );
            colorTable.Add ( new ColorData ( "{!strike}",   "\x1B[29m", "Strikethrough Off" ) );

            // Foreground
            colorTable.Add ( new ColorData ( "{black}",     "\x1B[30m", "Foreground black" ) );
            colorTable.Add ( new ColorData ( "{red}",       "\x1B[31m", "Foreground red" ) );
            colorTable.Add ( new ColorData ( "{green}",     "\x1B[32m", "Foreground green" ) );
            colorTable.Add ( new ColorData ( "{yellow}",    "\x1B[33m", "Foreground yellow" ) );
            colorTable.Add ( new ColorData ( "{blue}",      "\x1B[34m", "Foreground blue" ) );
            colorTable.Add ( new ColorData ( "{magenta}",   "\x1B[35m", "Foreground magenta" ) );
            colorTable.Add ( new ColorData ( "{cyan}",      "\x1B[36m", "Foreground cyan" ) );
            colorTable.Add ( new ColorData ( "{white}",     "\x1B[37m", "Foreground white" ) );

            // Background
            colorTable.Add ( new ColorData ( "{!black}",    "\x1B[40m", "Background black" ) );
            colorTable.Add ( new ColorData ( "{!red}",      "\x1B[41m", "Background red" ) );
            colorTable.Add ( new ColorData ( "{!green}",    "\x1B[42m", "Background green" ) );
            colorTable.Add ( new ColorData ( "{!yellow}",   "\x1B[43m", "Background yellow" ) );
            colorTable.Add ( new ColorData ( "{!blue}",     "\x1B[44m", "Background blue" ) );
            colorTable.Add ( new ColorData ( "{!magenta}",  "\x1B[45m", "Background magenta" ) );
            colorTable.Add ( new ColorData ( "{!cyan}",     "\x1B[46m", "Background cyan" ) );
            colorTable.Add ( new ColorData ( "{!white}",    "\x1B[47m", "Background white" ) );
        } 

        #endregion

        /// <summary>
        /// take string and change the {color} token with the proper escape codes
        /// </summary>
        /// <param name="stringToColor"></param>
        /// <returns></returns>
        public static string Colorize ( string stringToColor )
        {
            // Loop through our table
            foreach ( ColorData colorData in colorTable )
                // Replace our identifier with our code
                stringToColor = stringToColor.Replace ( colorData.Identifier, colorData.Code );

            // Return our colored string
            return ( stringToColor );
        } 
    }

    struct ColorData
    {
        #region Private Variables

        string identifier;
        string code;
        string definition;

        #endregion

        #region Public Properties

        public string Code
        {
            get { return code; }
        } // End of ReadOnly Code

        public string Identifier
        {
            get { return identifier; }
        } // End of ReadOnly Identifier

        public string Definition
        {
            get { return definition; }
        } // End of ReadOnly Definition

        #endregion

        public ColorData ( string identifier, string code, string definition )
        {
            // Set our values
            this.identifier = identifier;
            this.code = code;
            this.definition = definition;
        } 

    }
}
