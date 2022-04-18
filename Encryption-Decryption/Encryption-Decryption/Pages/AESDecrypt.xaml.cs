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
using System.Windows.Shapes;
using EncryptionDecryption.Helper;

namespace EncryptionDecryption.Pages
{
    /// <summary>
    /// Interaction logic for AESDecrypt.xaml
    /// </summary>
    public partial class AESDecrypt : Page
    {
        public string DataToDecrypt = "";
        

        public AESDecrypt()
        {
            InitializeComponent();
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {
            string plain = "";
            DecryptionHelper.SelectFile(out DataToDecrypt);
            txtPlain.Text = DataToDecrypt;
        }

        void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            var Encrypteddata = new byte[] { };
            var txt = "";
            var pwd = txtPassword.Text;
            //dec.AESEncryptFile(pwd, DataToDecrypt, out Encrypteddata);
            DecryptionHelper.AESDecryptFile(pwd,DataToDecrypt);
            foreach (var bytes in Encrypteddata)
            {
                txt += bytes;
            }
            txtEncrypted.Text = txt;
        }
    }
}
