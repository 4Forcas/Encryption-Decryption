using System;
using System.Windows;
using System.Windows.Controls;
using EncryptionDecryption.Helper;

namespace EncryptionDecryption.Pages
{
    public partial class DecryptAES : Page
    {
        public byte[] dataToDecrypt;
        public string decryptedData;

       
        public DecryptAES()
        {
            InitializeComponent();
        }

        void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            string key;
            DecryptionHelperAES.SelectKey(out key);
            DecryptionHelperAES.DecryptFile(dataToDecrypt, key, out decryptedData);
            key = "";
            txtDecryptedAES.Text = decryptedData;
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {
            DecryptionHelperAES.SelectFile(out dataToDecrypt);
            txtEncryptedAES.Text = String.Join("", dataToDecrypt);
        }
}
}
