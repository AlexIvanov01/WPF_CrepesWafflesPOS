using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Commands
{
    public class FoodTemplateDecreaseCounterCommand : ICommand 
    {
        private readonly FoodTemplateViewModel _foodTemplateViewModel;

        public FoodTemplateDecreaseCounterCommand(FoodTemplateViewModel viewModel)
        {
            _foodTemplateViewModel = viewModel;
            _foodTemplateViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _foodTemplateViewModel.Counter > 0;
        }

        public void Execute(object? parameter)
        {
            _foodTemplateViewModel.Counter--;
        }

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FoodTemplateViewModel.Counter))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
