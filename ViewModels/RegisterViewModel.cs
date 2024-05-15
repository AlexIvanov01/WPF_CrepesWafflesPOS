using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CrepesWaffelsPOS.Models;
using System.Windows.Input;
using CrepesWaffelsPOS.Commands;
using CrepesWaffelsPOS.Views;
using System.Security;
using System.Windows.Controls;
using System.Windows;

namespace CrepesWaffelsPOS.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private string _userName = string.Empty;
        private double _balance = 0;

        public double Balance
        {
            get { return _balance; }
            set 
            {
                _balance = value;
                OnPropertyChanged("Balance");
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
        public RegisterView View { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand CreateCommand { get; set; }

        public RegisterViewModel(RegisterView view)
        {
            View = view;
            CreateCommand = new CreateUserToDataBaseCommand(this);
            CancelCommand = new SwitchToLoginViewCommand(this);
        }
    }
}
