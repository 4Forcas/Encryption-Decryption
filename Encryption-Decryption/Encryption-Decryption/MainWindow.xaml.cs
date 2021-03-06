using EncryptionDecryption.Pages;
using System.Windows;
using System.Windows.Input;

namespace EncryptionDecryption
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void tg_Btn_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void Decrypt_Clicked(object sender, RoutedEventArgs e) => frMain.Content = new Decrypt();
        private void Encrypt_Clicked(object sender, RoutedEventArgs e) => frMain.Content = new Encrypt();
        private void EncryptAES_Clicked(object sender, RoutedEventArgs e) => frMain.Content = new EncryptAES();
        private void DecryptAES_Clicked(object sender, RoutedEventArgs e) => frMain.Content = new DecryptAES();
        private void BtnClose_Click(object sender, RoutedEventArgs e) => this.Close();
        private void Btnminimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.DragMove();

        private void ListBoxItem_OnSelected(object sender, RoutedEventArgs e) => frMain.Content = new GenerateKeys();
    }
}
