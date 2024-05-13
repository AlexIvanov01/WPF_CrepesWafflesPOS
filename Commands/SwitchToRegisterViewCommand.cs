using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CrepesWaffelsPOS.ViewModels;
using CrepesWaffelsPOS.Views;

namespace CrepesWaffelsPOS.Commands
{
    public class SwitchToRegisterViewCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        public event EventHandler? CanExecuteChanged;

        public SwitchToRegisterViewCommand(LoginViewModel viewModel)
        {
            _loginViewModel = viewModel;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Window window = new RegisterView();
            window.Show();
            _loginViewModel.View.Close();
        }
    }
}
