using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CrepesWaffelsPOS.Components;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Commands
{
    public class CreateFoodCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        private readonly AddFoodViewModel _foodViewModel;
        private MainWindowViewModel _mainWindowViewModel;

        public CreateFoodCommand(AddFoodViewModel viewModel, MainWindowViewModel mainWindowViewModel)
        {
            _foodViewModel = viewModel;
            _mainWindowViewModel = mainWindowViewModel;
            _foodViewModel.PropertyChanged += OnPropertyChanged;
        }
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        private void OnPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(AddFoodViewModel.Name) ||
                e.PropertyName == nameof(AddFoodViewModel.Price) ||
                e.PropertyName == nameof(AddFoodViewModel.SelectedCategory))
            {
                OnCanExecuteChanged();
            }
        }

        public bool CanExecute(object? parameter)
        {
           return _foodViewModel.Name != string.Empty &&
                  _foodViewModel.Price != 0;
        }

        public void Execute(object? parameter)
        {
            FoodModel newFood = new FoodModel()
            {
                Name = _foodViewModel.Name,
                Price = _foodViewModel.Price,
                Category = _foodViewModel.SelectedCategory
            };

            FoodTemplate foodTemplate = new FoodTemplate(newFood);

            _mainWindowViewModel.Foods.Add(foodTemplate);
            foodTemplate.viewModel.PropertyChanged += _mainWindowViewModel.OnFoodTemplateCounterChanged;

            using(DataAccess da = new DataAccess())
            {
                da.AddFood(newFood);
            }

            MessageBox.Show($"{newFood.Name} successfully added!","Info", MessageBoxButton.OK, MessageBoxImage.Information);
            _foodViewModel.View.Close();
        }
    }
}
