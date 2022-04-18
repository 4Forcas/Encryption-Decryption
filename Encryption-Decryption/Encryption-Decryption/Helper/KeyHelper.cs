using Microsoft.Win32;
using System;
using System.IO;
using System.Security.Cryptography;

namespace EncryptionDecryption.Helper
{
    public class KeyHelper
    {
        static void GenerateRSAKey(out string publickey, out string privatekey)
        {
            var rsa = new RSACryptoServiceProvider();
            publickey = Convert.ToBase64String(rsa.ExportRSAPublicKey());
            privatekey = Convert.ToBase64String(rsa.ExportRSAPrivateKey());
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
                string publicKeyPath = Path.Combine(folderPath, "publicKey.xml");
                string privateKeyPath = Path.Combine(folderPath, "privateKey.xml");
                string publickey;
                string privatekey;
                GenerateRSAKey(out publickey, out privatekey);
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
