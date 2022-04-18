using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace EncryptionDecryption.Helper
{
    public class DecryptionHelper
    {

        public static void RSADecryptFile(byte[] data, string key, out string decrypted)
        {
            decrypted = null;
            using (var rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportRSAPrivateKey(Convert.FromBase64String(key), out int temp);
                var decryptedData = rsa.Decrypt(data, false);
                var sfd = new SaveFileDialog()
                {
                    CheckFileExists = false,
                    FileName = "Location",
                    Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",

            };
                if (sfd.ShowDialog() == true)
                {
                    string folderPath = Path.GetDirectoryName(sfd.FileName);
                    string file = Path.Combine(folderPath, "DecryptedData.txt");
                    using (var sw = File.CreateText(file))
                    {
                        sw.Write(Encoding.Unicode.GetString(decryptedData));
                        decrypted += Encoding.Unicode.GetString(decryptedData);
                    }
                }
            }
        }


        public static void RSASelectKey(out string key)
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


        public static void RSASelectFile(out byte[] dataToConvert)
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
