using System;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Mountain.classes.handlers {

    public static class Extensions {

        // hide/change before shifting to production
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("zk37pEji3L0t73Q5");
        private const string passPhrase = "my wee lit^le do_keydunk Duck#y DingdYnglededoo4U";

        #region arrays

        public static string GetNames(Array list) {
            string names = string.Empty;
            int i = 1;
            foreach (Identity item in list) {
                names = names + item.Name;
                if (i != list.Length) { names = names + ", "; }
                if (i == list.Length) { names = names + "."; }
                i++;
            }
            return names;
        }

        #endregion

        #region string extensions

        public static string StripNewLine(this string str) {
            return Regex.Replace(str, @"\n|\r", "");
        }

        public static bool IsYes(this string str) { // we will just check the first char to see if the intent was Yes
            return (String.Equals(str.Substring(0, 1), "Y", StringComparison.OrdinalIgnoreCase));
        }

        public static string NewLine(this string str) {
            return str + Environment.NewLine;
        }

        public static string Indent(this string str) {
            return "\t" + str;
        }

        public static string ToProper(this string str) { // make all words' first char uppercase
            TextInfo info = new CultureInfo("en-US", false).TextInfo;
            return info.ToTitleCase(str);
        }

        public static bool IsNumeric(this string value) {
            float result; // ignore output
            return float.TryParse(value, out result); // an error returns false
        }

        public static bool IsNumberOnly(this string value, bool floatPoint) { // string representation of a number?
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
        public static bool IsNullOrWhiteSpace(this string value) { // better string.empty test
            return String.IsNullOrWhiteSpace(value);
        }
        public static string Camelize(this string str) { // return camel-case words in string ie: "joe moe" = "JoeMoe"
            return str.ToProper().Replace(" ", string.Empty);
        }
        public static string FirstWord(this string str) { // gets the first word of a sentence
            str = str.TrimStart(' ');
            if (str.WordCount() > 1) {
                return str.Substring(0, str.IndexOf(" "));
            }
            return str;
        }
        public static char FirstChar(this string str) {
            return str[0];
        }
        public static string StripFirstChar(this string str) {
            return str.Substring(1);
        }
        public static bool HasLastCharPunctuation(this string str) {
            if (str.IsNullOrWhiteSpace())
                return true;
            if (str.Length == 1)
                return Char.IsPunctuation(str[0]);
            return Char.IsPunctuation(str[str.Length - 1]);
        }
        public static string StripFirstWord(this string str) { // returns all but the first word
            if (str.WordCount() > 1) {
                return str.Substring(str.FirstWordLength()).Trim();
            }
            return "";
        }
        public static int WordCount(this string str) {
            char[] delimiterChars = { ' ', ',', '.', ':', '\t' };
            string[] words = str.Split(delimiterChars);
            return words.Length;
        }
        public static int FirstWordLength(this string str) {
            str = str.Trim();
            if (str.WordCount() > 1) {
                string first = str.Substring(0, str.IndexOf(" "));
                first = first.Trim();
                return first.Length;
            }
            return str.Length;
        }
        public static string StripExtraSpaces(this string str) {
            string build = str.Trim();
            string result = string.Empty;
            while (build.Length > 0) {
                result += build.FirstWord().Trim() + " ";
                build = build.StripFirstWord();
                build = build.Trim();
            }
            result = result.Trim();
            return result;
        }

        
        private const int keysize = 256;
        public static string Encrypt(this string plainText) {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null)) {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged()) {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes)) {
                        using (MemoryStream memoryStream = new MemoryStream()) {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)) {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }
        public static string Decrypt(this string cipherText) {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null)) {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged()) {
                    symmetricKey.Mode = CipherMode.CBC;
                    using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes)) {
                        using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes)) {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read)) {
                                byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }



        #endregion

        #region Ansi

        public static string ClearScreenWithTab(this string str, int size) {
            return "\x1B[2J" + "\x1B[" + size.ToString() + "C" + "\x1B[H" + str;
        }

        public static string WordWrap(this string sentence, int width) {  // takes a long string and formats to width
            StringBuilder lines = new StringBuilder();
            string[] words = sentence.Split(' ');
            StringBuilder buildLine = new StringBuilder("");
            foreach (var word in words) {
                if (word.Length + buildLine.Length + 1 > width) { // check if have we exceeded line width
                    lines.Append(buildLine.ToString().Indent().NewLine());
                    buildLine.Clear();
                }
                buildLine.Append((buildLine.Length == 0 ? "" : " ") + word);  // remove space at start of new line
            }
            if (buildLine.Length > 0) { // finished loop, check for final words to include
                lines.Append(buildLine.ToString().Indent().NewLine());
            }
            return lines.ToString();
        }

        #endregion
    }
}
