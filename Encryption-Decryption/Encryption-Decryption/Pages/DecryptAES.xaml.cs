using EncryptionDecryption.Helper;
using System;
using System.Windows;
using System.Windows.Controls;

namespace EncryptionDecryption.Pages
{
    public partial class DecryptAES : Page
    {
        public byte[] dataToDecrypt;
        public string decryptedData;
        public string key;
        string password;
        public DecryptAES()
        {
            InitializeComponent();
        }

        void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            txtDecryptedAES.Text = EncryptionDecryptionHelperAES.Decrypted(Convert.ToString(key), password);
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {
            DecryptionHelper.SelectKey(out key);
            txtEncryptedAES.Text = String.Join("", key);
        }

        private void pswdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = pswdBox.Text; ;
        }
    }
}
