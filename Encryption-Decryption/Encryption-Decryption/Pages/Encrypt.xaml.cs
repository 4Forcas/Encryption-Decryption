using System.ComponentModel;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace EncryptionDecryption.Pages
{
    public partial class Encrypt : Page
    {
        public Encrypt()
        {
            InitializeComponent();
        }

        void btnGenerate_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.CheckFileExists = false;
            ofd.FileName = "Location";
            if (ofd.ShowDialog() == true)
            {
                string folderPath = Path.GetDirectoryName(ofd.FileName);
                string publicKeyPath = Path.Combine(folderPath, "publicKey.xml");
                string privateKeyPath = Path.Combine(folderPath, "privateKey.xml");
                string publickey;
                string privatekey;
                GenerateRSAKey(out publickey, out privatekey);
                using (var sw = File.CreateText(publicKeyPath))
                {
                    sw.Write(publickey);
                }
                using (var sw = File.CreateText(privateKeyPath))
                {
                    sw.Write(privatekey);
                }
            }
        }


        public void GenerateRSAKey(out string publickey, out string privatekey)
        {
            var rsa = new RSACryptoServiceProvider();
            publickey = rsa.ToXmlString(false);
            privatekey = rsa.ToXmlString(true);
        }


        private void btnFile_Click(object sender, RoutedEventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
            };
            if (ofd.ShowDialog() == true)
            {
                

            }

        }

        private void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
