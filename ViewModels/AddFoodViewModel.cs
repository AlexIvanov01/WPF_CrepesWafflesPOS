using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CrepesWaffelsPOS.Commands;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.Views;

namespace CrepesWaffelsPOS.ViewModels
{
    public class AddFoodViewModel : BaseViewModel
    {
        public AddFoodView View { get; set; }
        public Array FoodTypes => Enum.GetValues(typeof(FoodCategory));
        private string _name = string.Empty;
        private double _price = 0;
        private FoodCategory _selectedCategory = 0;

        public FoodCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set 
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public double Price
        {
            get { return _price; }
            set 
            { 
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        public string Name
        {
            get { return _name; }
            set 
            { 
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public ICommand AddCommand { get; set; }

        public AddFoodViewModel(AddFoodView view ,MainWindowViewModel mainWindowViewModel)
        {
            View = view;
            AddCommand = new CreateFoodCommand(this, mainWindowViewModel);
        }
    }
}

