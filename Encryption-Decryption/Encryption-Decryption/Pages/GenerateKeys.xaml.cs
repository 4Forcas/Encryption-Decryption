using EncryptionDecryption.Helper;
using System.Windows;
using System.Windows.Controls;

namespace EncryptionDecryption.Pages
{
    public partial class GenerateKeys : Page
    {
        public GenerateKeys()
        {
            InitializeComponent();
        }

        void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            string publicKey;
            string privateKey;

            KeyHelper.SaveKeys(out publicKey, out privateKey);
            txtPublicKey.Text = publicKey;
            txtPrivateKey.Text = privateKey;
        }
    }
}
