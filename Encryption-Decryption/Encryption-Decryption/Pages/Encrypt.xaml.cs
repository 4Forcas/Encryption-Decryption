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

        string EncryptionMethod { get; set; } = "RSA";

        public Encrypt()
        {
            InitializeComponent();
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {
            switch (EncryptionMethod)
            {
                case "RSA":
                    EncryptionHelper.SelectFile(out selectedFile, out plainText);
                    break;
                case "AES":
                    EncryptionHelper.SelectFile(out selectedFile,out plainText);
                    break;
                default:

                    break;
            }

            txtPlain.Text = plainText;
        }
        void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            string key;
            string pKey;
            switch (EncryptionMethod)
            {
                case "RSA":
                    EncryptionHelper.SelectKey(out key);
                    EncryptionHelper.RSAEncryptFile(selectedFile, key, out encryptedData);
                    break;
                case "AES":
                    EncryptionHelper.SelectKey(out pKey);
                    EncryptionHelper.SelectKey(out key);
                    EncryptionHelper.AESEncryptFile(pKey, key, Convert.ToBase64String(selectedFile));
                    break;
                default:
                 
                    break;
            }


            txtEncrypted.Text = encryptedData;
        }

        void cbxOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)cbxOption.SelectedItem;
            if (item.Content != null)
                EncryptionMethod = item.Content.ToString();
        }
    }
}
