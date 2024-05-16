using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Commands
{
    public class AddToBalanceCommand : ICommand
    {
        private readonly MainWindowViewModel _viewModel;

        public AddToBalanceCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            double newBalance = _viewModel.Balance + 100;
            _viewModel.curUser.Balance = newBalance;
            _viewModel.OnPropertyChanged("Balance");
            using (DataAccess da = new DataAccess())
            {
                da.UpdateUserBalance(_viewModel.Username, newBalance);
            }
            MessageBox.Show("Funds added!");
        }
    }
}
