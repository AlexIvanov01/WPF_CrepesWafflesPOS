
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;
using static System.Net.Mime.MediaTypeNames;

namespace CrepesWaffelsPOS.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window, INotifyPropertyChanged
    {
        private string _password = string.Empty;


        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public LoginView()
        {
            InitializeComponent();
            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(startupPath + "/Images/logo.png");
            bitmap.EndInit();
            LoginImage.Source = bitmap;
            LoginViewModel viewModel = new LoginViewModel(this);
            DataContext = viewModel;
        }
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            if (passwordBox != null)
            {
                Password = passwordBox.Password;
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
