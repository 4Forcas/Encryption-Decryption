using System;
using System.Windows;
using System.Windows.Controls;
using EncryptionDecryption.Helper;

namespace EncryptionDecryption.Pages
{
    public partial class Encrypt : Page
    {
        byte[] selectedFile;
        string plainText;
        string encryptedData;

        public Encrypt()
        {
            InitializeComponent();
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {

            EncryptionHelper.SelectFile(out selectedFile, out plainText);
            txtPlain.Text = plainText;
        }
        void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string key;
            string pKey;

            EncryptionHelper.SelectKey(out key);
            EncryptionHelper.RSAEncryptFile(selectedFile, key, out encryptedData);


            txtEncrypted.Text = encryptedData;
        }
    }
}
