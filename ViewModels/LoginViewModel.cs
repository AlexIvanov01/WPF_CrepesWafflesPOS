using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CrepesWaffelsPOS.Models;

namespace CrepesWaffelsPOS.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _userName = string.Empty;
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
        public string UserName
        {
            get { return _userName; }
            set 
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public UserModel User { get; set; }
        
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
