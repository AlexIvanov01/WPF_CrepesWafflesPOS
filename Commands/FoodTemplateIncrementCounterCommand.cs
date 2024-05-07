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

namespace CrepesWaffelsPOS.Commands
{
    class FoodTemplateIncrementCounterCommand : ICommand
    {
        private readonly FoodTemplateViewModel _foodTemplateViewModel;

        public FoodTemplateIncrementCounterCommand(FoodTemplateViewModel viewModel)
        {
            _foodTemplateViewModel = viewModel;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _foodTemplateViewModel.Counter++;
        }
        
    }
}
