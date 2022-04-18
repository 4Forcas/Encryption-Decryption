using EncryptionDecryption.Helper;
using System.Windows;
using System.Windows.Controls;
using static System.String;

namespace EncryptionDecryption.Pages
{
    public partial class Decrypt : Page
    {
        public byte[] dataToDecrypt;
        public string decryptedData;
        string key;

        public Decrypt()
        {
            InitializeComponent();
        }

        void btnDecrypt_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(key))
            {
                MessageBox.Show("Select An key");
                return;
            }

            if (dataToDecrypt == null && dataToDecrypt.Length == 0)
            {
                MessageBox.Show("Select An File");
                return;
            }

            DecryptionHelper.DecryptFile(dataToDecrypt, key, out decryptedData);
            txtDecrypted.Text = decryptedData;
        }

        void btnFile_Click(object sender, RoutedEventArgs e)
        {
            DecryptionHelper.SelectFile(out dataToDecrypt);
            txtEncrypted.Text = Join("", dataToDecrypt);
        }

        private void BtnKey_OnClick(object sender, RoutedEventArgs e)
        {
            DecryptionHelper.SelectKey(out key);
        }
    }
}
