using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CrepesWaffelsPOS.Commands;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.Views;

namespace CrepesWaffelsPOS.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName = string.Empty;
        public LoginView View { get; set; }

        public string UserName
        {
            get { return _userName; }
            set 
            {
                _userName = value;
                OnPropertyChanged("UserName");
            }
        }

        public LoginViewModel(LoginView view)
        {
            View = view;
            LoginCommand = new CheckUserCredentialsCommand(this);
            RegisterCommand = new SwitchToRegisterViewCommand(this);
        }
        
        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand OrderCommand { get; set; }
    }
}
