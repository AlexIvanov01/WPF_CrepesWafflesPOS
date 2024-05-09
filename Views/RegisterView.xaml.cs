using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Views
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window, INotifyPropertyChanged
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

        public RegisterView()
        {
            InitializeComponent();
            RegisterViewModel viewModel = new RegisterViewModel(this);
            DataContext = viewModel;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void TextBox_NumericLimitTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the entered character is a digit or a valid decimal separator
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true; // Mark the event as handled to prevent the character from being entered
            }
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
    }
}
