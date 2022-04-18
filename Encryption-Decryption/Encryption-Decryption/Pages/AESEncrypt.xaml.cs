using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using EncryptionDecryption.Helper;

namespace EncryptionDecryption.Pages
{
    /// <summary>
    /// Interaction logic for AESEncrypt.xaml
    /// </summary>
    public partial class AESEncrypt : Page
    {
        public byte[] DataToEncrypt = new byte[] { };
        public AESEncrypt()
        {
            InitializeComponent();
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {

            string plain = "";
            EncryptionHelper.SelectFile(out DataToEncrypt, out plain);
            txtPlain.Text = plain;
        }

        void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var Encrypteddata = new byte[] { };
            var txt = "";
            var pwd = txtPassword.Text;
            EncryptionHelper.AESEncryptFile(pwd, DataToEncrypt, out Encrypteddata);
            foreach (var bytes in Encrypteddata)
            {
                txt += bytes;
            }
            txtEncrypted.Text = txt;

        }
    }
}
