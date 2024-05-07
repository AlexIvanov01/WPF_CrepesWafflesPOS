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
using System.Windows.Input;
using System.Windows.Media;
using CrepesWaffelsPOS.Commands;
using CrepesWaffelsPOS.Components;
using CrepesWaffelsPOS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CrepesWaffelsPOS.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly DataAccess _dbContext;
        private ObservableCollection<FoodTemplate> _foods;

        public ObservableCollection<FoodTemplate> Foods
        {
            get { return _foods; }
            set
            {
                _foods = value;
            }
        }
        public MainWindowViewModel(DataAccess dbContext)
        {
            _dbContext = dbContext;
            _foods = new ObservableCollection<FoodTemplate>();
            LoadFoods();
        }

        private void LoadFoods()
        {
            try
            {
                var FoodsList = _dbContext.GetFoods();
                foreach (var food in FoodsList) 
                {
                    var foodTemplate = new FoodTemplate(food);
                    Foods.Add(foodTemplate);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading foods: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
