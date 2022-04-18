using EncryptionDecryption.Helper;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace EncryptionDecryption.Pages
{
    public partial class EncryptAES : Page
    {
        byte[] selectedFile;
        string plainText;
        string encryptedData;
        string password;

        public EncryptAES()
        {
            InitializeComponent();
        }

 
        void btnFile_Click(object sender, RoutedEventArgs e)
        {
            EncryptionHelper.SelectFile(out selectedFile, out plainText);
            txtPlainAES.Text = plainText;
        }
        void btnEncrypt_Click(object sender, RoutedEventArgs e)
        {
            if (password.Length < 32 || password.Length > 32)
            {
                MessageBox.Show($"Password needs to be exactly 32 characters. \nThe password you entered has {password.Length} characters","Error");
                return;
            }

            if(selectedFile == null)
            {
                MessageBox.Show($"Please select a file with content first.","Error");
                return;
            }

            string folderPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";
            string file = Path.Combine(folderPath, "EncryptedDataAES.txt");

            var encm = EncryptionDecryptionHelperAES.Encrypt(txtPlainAES.Text, password);
            //Write encoded message 
            File.WriteAllText(file, encm);

            txtEncryptedAES.Text = encm;
        }

        private void aesPswdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = aesPswdBox.Text;
        }

        private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            aesPswdBox.Text = GenerateRandomCryptographicKey(22);
            //Write password to Downloads folder
            string folderPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";
            string file = Path.Combine(folderPath, "GeneratedAESPassword.txt");
            File.WriteAllText(file, aesPswdBox.Text);

            password = aesPswdBox.Text;
        }
        public string GenerateRandomCryptographicKey(int keyLength)
        {
            RNGCryptoServiceProvider rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            byte[] randomBytes = new byte[keyLength];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }
    }
}
