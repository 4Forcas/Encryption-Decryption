using System.Windows;
using System.Windows.Controls;
using EncryptionDecryption.Helper;

namespace EncryptionDecryption.Pages
{
    public partial class GenerateKeys : Page
    {
        string EncryptionMethod { get; set; } = "RSA";

        public GenerateKeys()
        {
            InitializeComponent();
        }

        void btnGenerate_Click(object sender, RoutedEventArgs e)
        {

            string publicKey;
            string privateKey;
            KeyHelper.RSASaveKeys(out publicKey, out privateKey,EncryptionMethod);
            txtPublicKey.Text = publicKey;
            txtPrivateKey.Text = privateKey;

        }

        void cbxOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (ComboBoxItem)cbxOption.SelectedItem;
            if (item.Content != null)
                EncryptionMethod = item.Content.ToString();
        }
    }
}
