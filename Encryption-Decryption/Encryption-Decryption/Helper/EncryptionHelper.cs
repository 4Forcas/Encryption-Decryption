using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace EncryptionDecryption.Helper
{
    public class EncryptionHelper
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

        public static void EncryptFile(byte[] dataToEncrypt, string key, out string encryptedFile)
        {
            encryptedFile = "";
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportRSAPublicKey(Convert.FromBase64String(key), out int temp);
                var encryptedData = rsa.Encrypt(dataToEncrypt, false);
                var base64 = Convert.ToBase64String(encryptedData);
                encryptedFile = base64;
                var ofd = new OpenFileDialog
                {
                    CheckFileExists = false,
                    FileName = "Location"
                };
                if (ofd.ShowDialog() == true)
                {
                    string folderPath = Path.GetDirectoryName(ofd.FileName);
                    string file = Path.Combine(folderPath, "EncryptedData.txt");

                    using (var sw = File.CreateText(file))
                    {
                        sw.Write(base64);
                    }

                }
            }
        }

        public static void SelectKey(out string key)
        {
            string mKey = "";
            var ofd = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
            };

            if (ofd.ShowDialog() == true)
            {
                mKey = File.ReadAllText(ofd.FileName);
            }
            key = mKey;
        }
    }
}
