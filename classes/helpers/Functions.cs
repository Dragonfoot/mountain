using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading.Tasks;

namespace Mountain.classes.helpers {

    public static class Functions {

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
            return Regex.Replace(str, @"\t|\n|\r", "");
        }

        public static bool IsYes(this string str) { // we will just check the first char to see if the intent was Yes
            return (String.Equals(str.Substring(0, 1), "Y", StringComparison.OrdinalIgnoreCase));
        }

        public static string NewLine(this string str) {
            return str + Environment.NewLine;
        }

        public static string WordWrap(this string sentence, int width) {  // takes a long string and formats to width
            StringBuilder lines = new StringBuilder();
            string[] words = sentence.Split(' ');
            StringBuilder buildLine = new StringBuilder("");
            foreach (var word in words) {
                if (word.Length + buildLine.Length + 1 > width) { // have we exceeded line width?
                    lines.Append(buildLine.ToString().Indent(Global.indent).NewLine()); 
                    buildLine.Clear(); 
                }
                buildLine.Append((buildLine.Length == 0 ? "" : " ") + word);  // no space at start of new line
            }
            if (buildLine.Length > 0) { // finished loop, check for final words to include
                lines.Append(buildLine.ToString().Indent(Global.indent).NewLine());
            }
            return lines.ToString();
        }

        public static string Indent(this string str, int size) { //  find ansi code for tab settings?
            return str.PadLeft(size);
        }

        public static string ToProper(this string str) { // make all words uppercase
            TextInfo info = new CultureInfo("en-US", false).TextInfo;
            return info.ToTitleCase(str);
        }

        public static bool IsNumeric(this string value) {
            float result; // ignore output
            return float.TryParse(value, out result); // an error returns false
        }

        public static bool IsNumberOnly(this string value, bool floatPoint) { // is it a string representation of a number
            value = value.Trim();
            if (value.Length == 0) return false;
            foreach (char chr in value) {
                if (!char.IsDigit(chr)) {
                    if (floatPoint && (chr == '.')) continue;
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

        #endregion
    }

    #region cryptography 

    // will want to hide this at some point, exclude from github, then change IV sometime before production 
    public static class StringCipher {  // taken from somewhere on the web, was freely given.
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (key size / 8).  Default key size is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.

        private const string passPhrase = "my wee lit^le do_keydunk Duck#y DingdYnglededoo4U"; // will want to change and hide before production
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("zk37pEji3L0t73Q5"); // will need to change this at production

        // This constant is used to determine the key size of the encryption algorithm.
        private const int keysize = 256;

        public static string Encrypt(string plainText) {
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
        public static string Decrypt(string cipherText) {
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
    }
    #endregion
}
