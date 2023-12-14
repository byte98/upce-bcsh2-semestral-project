using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class which holds usefull string utility functions.
    /// </summary>
    internal abstract class StringUtils
    {
        /// <summary>
        /// Maximal size of one piece of CLOB.
        /// </summary>
        private const int ClobSize = 1024;

        /// <summary>
        /// Encrypts string.
        /// </summary>
        /// <param name="input">String which will be encrypted.</param>
        /// <param name="key">Key by which string will be encrypted.</param>
        /// <returns>Encrypted string.</returns>
        public static string Encrypt(string input, string key)
        {
            byte[] iv = new byte[16];
            byte[] arr;
            using (Aes aes = Aes.Create())
            {
                int maxSize = aes.LegalKeySizes.Max((keySize) =>  keySize.MaxSize);
                key = StringUtils.EnsizeBytes(key, maxSize / 8);
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            sw.Write(input);
                        }
                        arr = ms.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(arr);
        }

        /// <summary>
        /// Changes size of string.
        /// If required string is longer, remaining space is filled with defined fill,
        /// if required string is shorter, string is trimmed.
        /// </summary>
        /// <param name="str">String which size will be changed.</param>
        /// <param name="size">Required size of string.</param>
        /// <param name="fill">String which will occupy remaining space.</param>
        /// <returns>New string with required size.</returns>
        public static string Ensize(string str, int size, string fill = " ")
        {
            string reti = string.Empty;
            for (int i = 0; i < size; i++)
            {
                if (i < str.Length)
                {
                    reti += str[i];
                }
                else
                {
                    reti += fill;
                }
            }
            return reti;
        }

        /// <summary>
        /// Changes size (in bytes) of string.
        /// If required string is longer, remaining space is filled with predefined fill,
        /// if required string is shorter, string is trimmed.
        /// </summary>
        /// <param name="str">String which size will be changed.</param>
        /// <param name="size">Required size of string (in bytes).</param>
        /// <param name="fill">String which will occupy remaining space.</param>
        /// <returns>New string with required size.</returns>
        public static string EnsizeBytes(string str, int size, string fill = " ")
        {
            string reti = string.Empty;
            int idx = 0;
            while (Encoding.UTF8.GetByteCount(reti) < size)
            {
                if (idx < str.Length)
                {
                    reti += str[idx];
                }
                else
                {
                    reti += fill;
                }
                idx++;
            }
            return reti;
        }

        /// <summary>
        /// Decrypts string.
        /// </summary>
        /// <param name="input">Encrypted string.</param>
        /// <param name="key">Key by which string has been encrypted.</param>
        /// <returns>Decrypted string.</returns>
        public static string? Decrypt(string? input, string key)
        {
            string? reti = null;
            if (input != null)
            {
                byte[] iv = new byte[16];
                byte[] arr = Convert.FromBase64String(input);
                using (Aes aes = Aes.Create())
                {
                    int maxSize = aes.LegalKeySizes.Max((keySize) => keySize.MaxSize);
                    key = StringUtils.EnsizeBytes(key, maxSize / 8);
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;
                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                    using (MemoryStream ms = new MemoryStream(arr))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                reti = sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            return reti;
        }

        /// <summary>
        /// Creates pseudo-random string.
        /// </summary>
        /// <param name="alphabet">Alphabet of allowed characters.</param>
        /// <param name="length">Length of string.</param>
        /// <returns>Pseudo-random string.</returns>
        public static string Random(string alphabet, uint length)
        {
            StringBuilder reti = new StringBuilder();
            Random random = new Random();
            for (uint i = 0; i < length; i++)
            {
                reti.Append(alphabet[random.Next(0, alphabet.Length)]);
            }
            return reti.ToString();
        }

        /// <summary>
        /// Creates pseudo-random string asynchronously.
        /// </summary>
        /// <param name="alphabet">Alphabet of allowed characters.</param>
        /// <param name="length">Length of string.</param>
        /// <returns>Task which resolves into pseudo-random string.</returns>
        public static Task<string> RandomAsync(string alphabet, uint length)
        {
            return Task<string>.Run(() =>
            {
                return StringUtils.Random(alphabet, length);
            });
        }

        /// <summary>
        /// Splits string to smaller strings.
        /// </summary>
        /// <param name="str">String which will be splitted.</param>
        /// <param name="size">Maximal length of one final string.</param>
        /// <returns>Array of smaller strings.</returns>
        public static string[] SplitBySize(string str, int size)
        {
            IList<string> reti = new List<string>();
            StringBuilder buffer = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                buffer.Append(str[i]);
                if (buffer.Length >= size)
                {
                    reti.Add(buffer.ToString());
                    buffer.Clear();
                }
            }
            return reti.ToArray();
        }

        /// <summary>
        /// Creates hash of string.
        /// </summary>
        /// <param name="str">String which hash will be computed.</param>
        /// <returns>Hash of string.</returns>
        public static string Hash(string str)
        {
            StringBuilder sb = new StringBuilder();
            byte[] hash;
            using (HashAlgorithm sha = SHA256.Create())
            {
                hash = sha.ComputeHash(Encoding.UTF8.GetBytes(str));
            }
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }


        /// <summary>
        /// String which contains whole english alphabet (in unspecified case).
        /// </summary>
        public static string EnglishAlphabet => "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// String which contains whole english in lower case.
        /// </summary>
        public static string EnglishAlphabetLower => StringUtils.EnglishAlphabet.ToLower();

        /// <summary>
        /// String which contains whole english in upper case.
        /// </summary>
        public static string EnglishAlphabetUpper => StringUtils.EnglishAlphabet.ToUpper();

        /// <summary>
        /// String which contains whole english alphabet in both cases (AaBbCcDdEeFf...)
        /// </summary>
        public static string EnglishAlphabetBoth
        {
            get
            {
                StringBuilder buffer = new StringBuilder();
                for (int i = 0; i < StringUtils.EnglishAlphabetUpper.Length; i++)
                {
                    buffer.Append(StringUtils.EnglishAlphabetUpper[i]);
                    buffer.Append(StringUtils.EnglishAlphabetLower[i]);
                }
                return buffer.ToString();
            }
        }

        /// <summary>
        /// String which contains all numeric characters.
        /// </summary>
        public static string Numbers => "0123456789";

        /// <summary>
        /// String which contains whole english alphabet in both cases and numeric characters.
        /// </summary>
        public static string EnglishBothAndNumbers => StringUtils.EnglishAlphabetBoth + StringUtils.Numbers;

        /// <summary>
        /// Shuffles string.
        /// </summary>
        /// <param name="str">String which characters will be shuffled.</param>
        /// <returns>String with shuffled characters.</returns>
        public static string Shuffle(string str)
        {
            IList<char> chars = new List<char>(str.ToCharArray());
            StringBuilder reti = new StringBuilder();
            Random rnd = new Random();
            while(chars.Count > 0)
            {
                int idx = rnd.Next(0, chars.Count);
                reti.Append(chars[idx]);
                chars.RemoveAt(idx);
            }
            return reti.ToString();
        }

        /// <summary>
        /// Transforms string into character large object.
        /// </summary>
        /// <param name="str">String which will be transformed.</param>
        /// <returns>String which contains query to create character large object.</returns>
        public static string ToClob(string str)
        {
            StringBuilder reti = new StringBuilder();
            string[] parts = StringUtils.SplitBySize(str, StringUtils.ClobSize);
            for (int i = 0; i < parts.Length; i++)
            {
                reti.Append("TO_CLOB('");
                reti.Append(parts[i]);
                reti.Append("')");
                if (i < parts.Length - 1)
                {
                    reti.Append("||");
                }
            }
            return reti.ToString();
        }
    }
}
