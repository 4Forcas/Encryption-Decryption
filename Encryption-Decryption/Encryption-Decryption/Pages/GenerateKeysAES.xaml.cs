using System.Windows;
using System.Windows.Controls;
using EncryptionDecryption.Helper;

namespace EncryptionDecryption.Pages
{
    public partial class GenerateKeysAES : Page
    {
        public GenerateKeysAES()
        {
            InitializeComponent();
        }

        void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string publicKey;
            string privateKey;

            KeyHelper.SaveKeys(out publicKey, out privateKey);
            txtPublicKeyAES.Text = publicKey;
            txtPrivateKeyAES.Text = privateKey;
        }
    }
}
