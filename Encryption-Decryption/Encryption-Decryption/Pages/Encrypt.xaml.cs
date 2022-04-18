using EncryptionDecryption.Helper;
using System.Windows;
using System.Windows.Controls;

namespace EncryptionDecryption.Pages
{
    public partial class Encrypt : Page
    {
        byte[] selectedFile;
        string plainText;
        string encryptedData;
        string key;

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
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Select An key");
                return;
            }

            if (selectedFile == null && selectedFile.Length == 0)
            {
                MessageBox.Show("Select An File");
                return;
            }

            EncryptionHelper.EncryptFile(selectedFile, key, out encryptedData);
            txtEncrypted.Text = encryptedData;
        }

        private void BtnKey_OnClick(object sender, RoutedEventArgs e)
        {
            EncryptionHelper.SelectKey(out key);
        }
    }
}
