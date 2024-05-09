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
        public FoodTemplateViewModel viewModel { get; set; }
        public FoodTemplate(FoodModel food)
        {
            InitializeComponent();
            Picture.Source = food.Category switch
            {
                FoodCategory.Burger => new BitmapImage(new Uri(@"C:\Програмиране\C#\CrepesWaffelsPOS\CrepesWaffelsPOS\Images\burger.jpeg", UriKind.Absolute)),
                FoodCategory.Crepe => new BitmapImage(new Uri(@"C:\Програмиране\C#\CrepesWaffelsPOS\CrepesWaffelsPOS\Images\crepe.jpg", UriKind.Absolute)),
                FoodCategory.Pizza => new BitmapImage(new Uri(@"C:\Програмиране\C#\CrepesWaffelsPOS\CrepesWaffelsPOS\Images\pizza.jpg", UriKind.Absolute)),
                FoodCategory.Soup => new BitmapImage(new Uri(@"C:\Програмиране\C#\CrepesWaffelsPOS\CrepesWaffelsPOS\Images\soup.jpeg", UriKind.Absolute)),
                FoodCategory.Waffle => new BitmapImage(new Uri(@"C:\Програмиране\C#\CrepesWaffelsPOS\CrepesWaffelsPOS\Images\waffle.jpg", UriKind.Absolute)),
                _ => new BitmapImage(new Uri(@"C:\Програмиране\C#\CrepesWaffelsPOS\CrepesWaffelsPOS\Images\crepe.jpg", UriKind.Absolute)),
            };
            viewModel = new FoodTemplateViewModel(food);
            DataContext = viewModel;
        }
    }
}
