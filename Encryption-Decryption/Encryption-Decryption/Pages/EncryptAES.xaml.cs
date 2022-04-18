using EncryptionDecryption.Helper;
using System;
using System.Diagnostics;
using System.IO;
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
            string folderPath = Environment.GetEnvironmentVariable("USERPROFILE") + @"\" + "Downloads";
            string file = Path.Combine(folderPath, "EncryptedDataAES.txt");

            var encm = EncryptionDecryptionHelperAES.Encrypt(txtPlainAES.Text, password);
            //Write encoded message 
            File.WriteAllText(file, encm);

            Debug.WriteLine(encm);
            txtEncryptedAES.Text = encm;
        }

        private void aesPswdBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            password = aesPswdBox.Text;
        }
    }
}
