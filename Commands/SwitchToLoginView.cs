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
    public class SwitchToLoginView : ICommand
    {
        private readonly RegisterViewModel _registerViewModel;
        public SwitchToLoginView(RegisterViewModel viewModel)
        {
            _registerViewModel = viewModel;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Window window = new LoginView();
            window.Show();
            _registerViewModel.View.Close();
        }
    }
}
