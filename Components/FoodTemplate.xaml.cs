using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Components
{
    public partial class FoodTemplate : UserControl
    {
        public FoodTemplateViewModel viewModel { get; set; }
        public FoodTemplate(FoodModel food)
        {
            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName);
            MessageBox.Show(startupPath + @"\Images\burger.jpeg");
            InitializeComponent();
            Picture.Source = food.Category switch
            {
                FoodCategory.Burger => new BitmapImage(new Uri(startupPath + @"\Images\burger.jpeg", UriKind.Absolute)),
                FoodCategory.Crepe => new BitmapImage(new Uri(startupPath + @"\Images\crepe.jpg", UriKind.Absolute)),
                FoodCategory.Pizza => new BitmapImage(new Uri(startupPath + @"\Images\pizza.jpg", UriKind.Absolute)),
                FoodCategory.Soup => new BitmapImage(new Uri(startupPath + @"\Images\soup.jpeg", UriKind.Absolute)),
                FoodCategory.Waffle => new BitmapImage(new Uri(startupPath + @"\Images\waffle.jpg", UriKind.Absolute)),
                _ => new BitmapImage(new Uri(startupPath + @"\Images\crepe.jpg", UriKind.Absolute)),
            };
            viewModel = new FoodTemplateViewModel(food);
            DataContext = viewModel;
        }
    }
}
