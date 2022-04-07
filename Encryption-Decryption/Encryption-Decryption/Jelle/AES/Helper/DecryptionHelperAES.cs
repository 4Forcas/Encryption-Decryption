using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace EncryptionDecryption.Helper
{
    public class DecryptionHelperAES
    {

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
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
