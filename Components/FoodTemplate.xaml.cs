using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Components
{
    /// <summary>
    /// Interaction logic for FoodTemplate.xaml
    /// </summary>
    public partial class FoodTemplate : UserControl
    {
        public FoodTemplate(FoodModel food)
        {
            InitializeComponent();
            var viewModel = new FoodTemplateViewModel(food);
            DataContext = viewModel;
        }
    }
}
