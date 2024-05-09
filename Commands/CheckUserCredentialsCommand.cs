using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Commands
{
    public class CheckUserCredentialsCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        public CheckUserCredentialsCommand(LoginViewModel viewModel)
        {
            _loginViewModel = viewModel;
            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _loginViewModel.UserName != string.Empty &&
                _loginViewModel.Password != string.Empty;
        }

        public void Execute(object? parameter)
        {
            using(DataAccess da = new DataAccess()) 
            {
                da.Database.EnsureCreated();

            }
        }
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.UserName) ||
                e.PropertyName == nameof(LoginViewModel.Password))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
