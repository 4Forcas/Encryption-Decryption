using System.Windows;
using System.Windows.Controls;
using EncryptionDecryption.Helper;

namespace EncryptionDecryption.Pages
{
    public partial class EncryptAES : Page
    {
        byte[] selectedFile;
        string plainText;
        string encryptedData;

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
            string key;
            EncryptionHelper.SelectKey(out key);
            EncryptionHelper.EncryptFile(selectedFile, key, out encryptedData);
            txtEncryptedAES.Text = encryptedData;
        }
    }
}
