using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
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

        public static void RSAEncryptFile(byte[] dataToEncrypt, string key, out string encryptedFile)
        {
            encryptedFile = "";
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportRSAPublicKey(Convert.FromBase64String(key), out int temp);
                var encryptedData = rsa.Encrypt(dataToEncrypt, false);
                var base64 = Convert.ToBase64String(encryptedData);
                encryptedFile = base64;
                var ofd = new SaveFileDialog()
                {
                    CheckFileExists = false,
                    FileName = "EncryptedData",
                    Filter = "XML files(.xml)|*.xml|all Files(*.*)|*.*",
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

        public static void AESEncryptFile(string password, byte[] aFile, out byte[] encryptedData)
        {
            var aes = new AesCryptoServiceProvider();
            aes.BlockSize = 128;
            aes.KeySize = 256;
            var x = Encoding.ASCII.GetBytes(password);
            aes.IV = x;
            aes.Key = x;
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            encryptedData = encryptor.TransformFinalBlock(aFile, 0, aFile.Length);
            var sfd = new SaveFileDialog()
            {
                FileName = "AESEncryptedData",
            };
            if (sfd.ShowDialog() == true)
            {
                string folderPath = Path.GetDirectoryName(sfd.FileName);
                string file = Path.Combine(folderPath, "AESEncryptedData.txt");

                using (var sw = File.CreateText(file))
                {
                    sw.Write(Convert.ToBase64String(encryptedData));
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
