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
    public class SwitchToLoginViewCommand : ICommand
    {
        private readonly RegisterViewModel? _registerViewModel;
        private readonly MainWindowViewModel? _mainWindowViewModel;
        public SwitchToLoginViewCommand(RegisterViewModel viewModel)
        {
            _registerViewModel = viewModel;
        }
        public SwitchToLoginViewCommand(MainWindowViewModel viewModel)
        {
            _mainWindowViewModel = viewModel;
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
            _registerViewModel?.View.Close();
            _mainWindowViewModel?.View.Close();
        }
    }
}
