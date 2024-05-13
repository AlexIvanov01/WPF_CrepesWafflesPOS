
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;

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
