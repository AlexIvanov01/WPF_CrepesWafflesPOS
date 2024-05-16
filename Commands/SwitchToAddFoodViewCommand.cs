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
    public class SwitchToAddFoodViewCommand : ICommand
    {
        private MainWindowViewModel viewModel;
        public event EventHandler? CanExecuteChanged;

        public SwitchToAddFoodViewCommand(MainWindowViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Window window = new AddFoodView(viewModel);
            window.Show();
        }
    }
}
