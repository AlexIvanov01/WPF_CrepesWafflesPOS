using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using CrepesWaffelsPOS.Commands;
using CrepesWaffelsPOS.Components;
using CrepesWaffelsPOS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CrepesWaffelsPOS.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<FoodTemplate> _foods;
        public string _order = "Empty order list.";
        public UserModel curUser { get; set; }
        public string Username => curUser.Username;
        public double Balance => curUser.Balance;

        public string Order
        {
            get { return _order; }
            set 
            { 
                _order = value;
                OnPropertyChanged("Order");
            }
        }


        public ObservableCollection<FoodTemplate> Foods
        {
            get { return _foods; }
            set
            {
                _foods = value;
            }
        }

        public MainWindowViewModel(UserModel user)
        {
            _foods = new ObservableCollection<FoodTemplate>();
            LoadFoods();
            curUser = user;
        }
        private void OnFoodTemplateCounterChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FoodTemplateViewModel.Counter))
            {
                GenerateReceipt();
            }
        }

        private void LoadFoods()
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {
                    var FoodsList = da.GetFoods();
                    foreach (var food in FoodsList)
                    {
                        var foodTemplate = new FoodTemplate(food);
                        foodTemplate.viewModel.PropertyChanged += OnFoodTemplateCounterChanged;
                        Foods.Add(foodTemplate);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading foods: {ex.Message}");
            }
        }

        public void GenerateReceipt()
        {
            StringBuilder receipt = new StringBuilder();
            double total = 0;
            var foodList = Foods.Where(i => i.viewModel.Counter > 0).ToList();

            if (foodList.Count != 0)
            {
                foreach (var food in foodList)
                {
                    double itemTotal = food.viewModel.Price * food.viewModel.Counter;
                    total += itemTotal;
                    receipt.Append($"{food.viewModel.Food.Name}: {food.viewModel.Food.Price}$ x {food.viewModel.Counter} = {itemTotal}$\n");
                }

                receipt.Append($"\nTotal: {total}$");

                Order = receipt.ToString();
            }
            else
            {
                Order = "Empty order list.";
            }
        }

    }
}
