using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace EncryptionDecryption.Helper
{
    public class KeyHelperAES
    {
        static void GenerateAESKey(out string publickey, out string privatekey)
        {
            Aes aes = Aes.Create();
            publickey = Convert.ToBase64String(aes.GenerateIV());
            privatekey = Convert.ToBase64String(aes.GenerateKey());
        }

        public static void SaveKeys(out string aPublicKey, out string aPrivateKey)
        {
            aPublicKey = "";
            aPrivateKey = "";
            var ofd = new OpenFileDialog
            {
                CheckFileExists = false,
                FileName = "Location"
            };
            if (ofd.ShowDialog() == true)
            {
                string folderPath = Path.GetDirectoryName(ofd.FileName);
                string publicKeyPath = Path.Combine(folderPath, "publicKey.txt");
                string privateKeyPath = Path.Combine(folderPath, "privateKey.txt");
                string publickey;
                string privatekey;
                GenerateAESKey(out publickey, out privatekey);
                using (var sw = File.CreateText(publicKeyPath))
                    sw.Write(publickey);
                using (var sw = File.CreateText(privateKeyPath))
                    sw.Write(privatekey);
                aPublicKey = publickey;
                aPrivateKey = privatekey;
            }
        }
    }
}
