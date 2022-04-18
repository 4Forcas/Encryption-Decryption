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
            if (password.Length < 32 || password.Length > 32)
            {
                MessageBox.Show($"Password needs to be exactly 32 characters. \nThe password you entered has {password.Length} characters", "Error");
                return;
            }

            if (key == null)
            {
                MessageBox.Show($"Please select a file with content first.", "Error");
                return;
            }

            try
            {
                txtDecryptedAES.Text = EncryptionDecryptionHelperAES.Decrypted(Convert.ToString(key), password);
            }
            catch (Exception)
            {
                if(password.Length > 32 || password.Length < 32)
                    MessageBox.Show("Password is invalid.", "Error");
                else
                    MessageBox.Show("Selected file is not encrypted with this password.","Error");
                return;
            }
            
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {
            DecryptionHelper.SelectKey(out key);
            txtEncryptedAES.Text = String.Join("", key);
        }

        private void pswdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = pswdBox.Text;
        }

        private void SelectPassword_Click(object sender, RoutedEventArgs e)
        {
            DecryptionHelper.SelectKey(out password);
            pswdBox.Text = password;
        }
    }
}
