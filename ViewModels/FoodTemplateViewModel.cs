using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CrepesWaffelsPOS.Commands;
using CrepesWaffelsPOS.Models;

namespace CrepesWaffelsPOS.ViewModels
{
    public class FoodTemplateViewModel : INotifyPropertyChanged
    {
        private FoodModel _food;
        public string Name => _food.Name;
        public double Price => _food.Price;
        private int _couneter = 0;

        public FoodModel Food
        {
            get { return _food; }
            set { _food = value; }
        }
        public int Counter
        {
            get { return _couneter; }
            set
            {
                _couneter = value;
                OnPropertyChanged("Counter");
            }
        }

        public FoodTemplateViewModel(FoodModel food)
        {
            _food = food;
            IncrementCounterCommand = new FoodTemplateIncrementCounterCommand(this);
            DecreaseCounterCommand = new FoodTemplateDecreaseCounterCommand(this);
        }

        public ICommand IncrementCounterCommand { get; set; }
        public ICommand DecreaseCounterCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
