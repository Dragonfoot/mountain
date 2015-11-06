using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Mountain.classes.helpers {

    public static class CommandLookup {

        public static VerbPacket Parse(string str, Account user) {
            List<string> commandLine = new List<string>();
            List<string> verb = new List<string>();
            str = str.StripExtraSpaces();
            string command = str.FirstWord();
         //   verb = GetCommand(command);
            command = command.ToLower();
            str = str.StripFirstWord();
            commandLine.Add(command);
            if (CheckCommunicating(command, commandLine, str, user)) {
                return commandLine;
            }

            commandLine.Add(command);
            string tail = str.StripFirstWord().TrimStart(' ');
            string[] parameters = tail.Split(' ');
            foreach (String parameter in parameters) {
                commandLine.Add(parameter);
            }

            return commandLine;
        }     

        private static bool CheckCommunicating(string command, List<string> commandLine, string str, Account user) {
            string who = string.Empty;
            bool handled = false;
            switch (command) {
                case "say":
                    commandLine.Add(" \"" + str + "\"");
                    handled = true;
                    break;
                case "tell":
                    who = str.FirstWord();
                    str = str.StripFirstWord();
                    commandLine.Add(who);
                    commandLine.Add(" \"" + str + "\"");
                    handled = true;
                    break;
                case "broadcast":
                case "broad":
                case "broa":
                    commandLine.Add(" \"" + str + "\"");
                    handled = true;
                    break;
                case "yell":
                    commandLine.Add(" \"" + str + "\"");
                    handled = true;
                    break;
                case "whisper":
                case "whisp":
                case "whis":
                    commandLine.Add(" \"" + str + "\"");
                    handled = true;
                    break;
            }
            return handled;
        }
    } // end command

   
}
