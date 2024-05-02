using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using CrepesWaffelsPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace CrepesWaffelsPOS.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly DataAccess _dbContext;
        private List<FoodModel> _foods;

        public List<FoodModel> Foods
        {
            get { return _foods; }
            set
            {
                _foods = value;
                OnPropertyChanged("Foods");
            }
        }
        public MainWindowViewModel(DataAccess dbContext)
        {
            _dbContext = dbContext;
            _foods = new List<FoodModel>();
            LoadFoodsAsync();
            MessageBox.Show($"{_foods.Count}","Message");
        }

        private void LoadFoodsAsync()
        {
            try
            {
                Foods = _dbContext.GetFoods();
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
