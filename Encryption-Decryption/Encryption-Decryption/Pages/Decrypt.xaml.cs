using System;
using System.Windows;
using System.Windows.Controls;
using EncryptionDecryption.Helper;

namespace EncryptionDecryption.Pages
{
    public partial class Decrypt : Page
    {
        public byte[] dataToDecrypt;
        public string decryptedData;

        public Decrypt()
        {
            InitializeComponent();
        }

        void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string key;
            DecryptionHelper.RSASelectKey(out key);
            DecryptionHelper.RSADecryptFile(dataToDecrypt, key, out decryptedData);
            txtDecrypted.Text = decryptedData;
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {
            DecryptionHelper.RSASelectFile(out dataToDecrypt);
            txtEncrypted.Text = String.Join("", dataToDecrypt);
        }

    }
}
