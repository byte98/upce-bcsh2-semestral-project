﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class which holds usefull string utility functions.
    /// </summary>
    internal abstract class StringUtils
    {
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
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);
                using (MemoryStream  ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
                    {
                        using (StreamWriter  sw = new StreamWriter(cs))
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
    }
}
