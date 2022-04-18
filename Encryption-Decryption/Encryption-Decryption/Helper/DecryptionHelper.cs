using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EncryptionDecryption.Helper
{
    public class DecryptionHelper
    {

        public static void DecryptFile(byte[] data, string key, out string decrypted)
        {
            decrypted = null;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(key), out int temp);
                var decryptedData = rsa.Decrypt(data, false);
                var ofd = new OpenFileDialog
                {
                    CheckFileExists = false,
                    FileName = "Location"
                };
                if (ofd.ShowDialog() == true)
                {
                    string folderPath = Path.GetDirectoryName(ofd.FileName);
                    string file = Path.Combine(folderPath, "DecryptedData.txt");
                    using (var sw = File.CreateText(file))
                    {
                        sw.Write(Encoding.Unicode.GetString(decryptedData));
                        decrypted += Encoding.Unicode.GetString(decryptedData);
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
                mKey = File.ReadAllText(ofd.FileName);
            key = mKey;
        }


        public static void SelectFile(out byte[] dataToConvert)
        {
            byte[] data = null;
            var ofd = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
            };
            if (ofd.ShowDialog() == true)
                using (var sr = new StreamReader(ofd.FileName))
                    data = Convert.FromBase64String(sr.ReadLine());
            dataToConvert = data;
        }
    }
}
