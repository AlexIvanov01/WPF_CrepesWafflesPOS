using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace CrepesWaffelsPOS.Commands
{
    public class CreateOrderCommand : ICommand
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public CreateOrderCommand(MainWindowViewModel viewModel)
        {
            _mainWindowViewModel = viewModel;
            _mainWindowViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public void OnViewModelPropertyChanged(object? sedner, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainWindowViewModel.Foods))
            {
                OnCanExecuteChanged();
            }
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _mainWindowViewModel.Foods.Any(food => food.viewModel.Counter != 0);
        }

        public void Execute(object? parameter)
        {
            try
            {
                var foodList = _mainWindowViewModel.Foods.Where(food => food.viewModel.Counter > 0).ToList();
                double price = 0;
                foreach (var food in foodList)
                {
                    price += food.viewModel.Price * food.viewModel.Counter;
                }
                if (price <= _mainWindowViewModel.curUser.Balance)
                {
                    MessageBox.Show($"Total amount about to be deducted form balance: {price}$", "Order", MessageBoxButton.OK, MessageBoxImage.Information);

                    double newBalance = _mainWindowViewModel.curUser.Balance - price;

                    using (var dbContext = new DataAccess())
                    {
                        dbContext.UpdateUserBalance(_mainWindowViewModel.Username, newBalance);
                    }

                    _mainWindowViewModel.curUser.Balance -= price;
                    _mainWindowViewModel.OnPropertyChanged("Balance");

                    foreach(var food in _mainWindowViewModel.Foods)
                    {
                        food.viewModel.Counter = 0;
                    }

                    _mainWindowViewModel.GenerateReceipt();
                }
                else
                {
                    MessageBox.Show("Not enough Balance for order", "Order", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured during transaction:\n{ex.Message}\nTransaction cancelled.","Error",MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
