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
        string EncryptionMethod { get; set; } = "RSA";

        public Decrypt()
        {
            InitializeComponent();
        }

        void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string key;
            switch (EncryptionMethod)
            {
                case "RSA":
                    DecryptionHelper.RSASelectKey(out key);
                    DecryptionHelper.RSADecryptFile(dataToDecrypt, key, out decryptedData);
                    break;
                case "AES":

                    break;
                default:

                    break;
            }
            txtDecrypted.Text = decryptedData;
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {

            switch (EncryptionMethod)
            {
                case "RSA":
                    DecryptionHelper.RSASelectFile(out dataToDecrypt);
                    break;
                case "AES":

                    break;
                default:

                    break;
            }
            txtEncrypted.Text = String.Join("", dataToDecrypt);
        }

        void cbxOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)cbxOption.SelectedItem;
            if (item.Content != null)
                EncryptionMethod = item.Content.ToString();
        }
    }
}
