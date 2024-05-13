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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CrepesWaffelsPOS.Commands;
using CrepesWaffelsPOS.Models;

namespace CrepesWaffelsPOS.ViewModels
{
    public class FoodTemplateViewModel : BaseViewModel
    {
        private int _couneter = 0;
        public string Name => Food.Name;
        public double Price => Food.Price;
        public FoodModel Food { get; set; }
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
            Food = food;
            IncrementCounterCommand = new FoodTemplateIncrementCounterCommand(this);
            DecreaseCounterCommand = new FoodTemplateDecreaseCounterCommand(this);
        }

        public ICommand IncrementCounterCommand { get; set; }
        public ICommand DecreaseCounterCommand { get; set; }
    }
}
