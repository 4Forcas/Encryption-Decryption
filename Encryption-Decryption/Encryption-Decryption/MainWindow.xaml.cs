using System.Windows;
using System.Windows.Input;
using EncryptionDecryption.Pages;

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
        private void BtnClose_Click(object sender, RoutedEventArgs e) => this.Close();
        private void Btnminimize_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => this.DragMove();

    }
}
