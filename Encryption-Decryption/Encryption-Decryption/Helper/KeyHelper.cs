using System;
using System.IO;
using System.Security.Cryptography;
using Microsoft.Win32;

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

        static void GenerateAESKey(out string publickey, out string privatekey)
        {
            var aes = new AesCryptoServiceProvider();
            aes.GenerateIV();
            aes.GenerateKey();
            publickey = Convert.ToBase64String(aes.IV);
            privatekey = Convert.ToBase64String(aes.Key);

        }

        public static void RSASaveKeys(out string aPublicKey, out string aPrivateKey, string Option)
        {
            aPublicKey = "";
            aPrivateKey = "";
            var sfd = new SaveFileDialog()
            {
                CheckFileExists = false,
                FileName = "Location",
                Filter = "XML files(.xml)|*.xml|all Files(*.*)|*.*",
            };

            if (sfd.ShowDialog() == true)
            {
                string folderPath = Path.GetDirectoryName(sfd.FileName);
                string publicKeyPath = Path.Combine(folderPath, "publicKey.xml");
                string privateKeyPath = Path.Combine(folderPath, "privateKey.xml");
                string publickey = "";
                string privatekey = "";
                switch (Option)
                {
                    case "RSA":
                        GenerateRSAKey(out publickey, out privatekey);
                        break;
                    case "AES":
                        GenerateAESKey(out publickey, out privatekey);
                        break;
                }

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
