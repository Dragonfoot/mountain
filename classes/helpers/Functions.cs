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
        #endregion

        #region string extensions

        public static string StripNewLine(this string str) {
            return Regex.Replace(str, @"\t|\n|\r", "");
        }
        public static string NewLine(this string str) {
            return str + Environment.NewLine;
        }
        public static string WordWrap(this string sentence, int width) {
            StringBuilder lines = new StringBuilder();
            string[] words = sentence.Split(' ');
            StringBuilder buildLine = new StringBuilder("");
            foreach (var word in words) {
                if (word.Length + buildLine.Length + 1 > width) {
                    lines.Append(buildLine.ToString().Indent(Global.indent).NewLine());
                    buildLine.Clear();
                }
                buildLine.Append((buildLine.Length == 0 ? "" : " ") + word);
            }
            if (buildLine.Length > 0) {
                lines.Append(buildLine.ToString().Indent(Global.indent).NewLine());
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
        #endregion
    }

    #region cryptography

    public static class StringCipher {  // from web
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("zk37pEji3L0t73Q5");

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public static string Encrypt(string plainText, string passPhrase) {
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
        public static string Decrypt(string cipherText, string passPhrase) {
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
