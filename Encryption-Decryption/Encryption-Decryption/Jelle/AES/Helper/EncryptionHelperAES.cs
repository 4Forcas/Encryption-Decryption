using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace EncryptionDecryption.Helper
{
        public class EncryptionHelperAES
        {

        public static void SelectFile(out byte[] dataToConvert, out string plain)
        {
            plain = "";
            byte[] data = null;
            var ofd = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
            };
            if (ofd.ShowDialog() == true)
                using (var sr = new StreamReader(ofd.FileName))
                {
                    var byteArr = Encoding.Unicode.GetBytes(sr.ReadToEnd());
                    data = byteArr;
                    plain = Encoding.Unicode.GetString(data);
                }

            dataToConvert = data;
        }

        public static string EncryptString(string key, string plainText)
            {
                byte[] iv = new byte[16];
                byte[] array;

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Encoding.UTF8.GetBytes(key);
                    aes.IV = iv;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                            {
                                streamWriter.Write(plainText);
                            }

                            array = memoryStream.ToArray();
                        }
                    }
                }

                return Convert.ToBase64String(array);
            }
        }
    }


