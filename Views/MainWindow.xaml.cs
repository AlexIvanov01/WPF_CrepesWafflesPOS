using System.Windows;
using CrepesWaffelsPOS.ViewModels;
using CrepesWaffelsPOS.Models;
using System.IO;
using System.Windows.Media.Imaging;


namespace CrepesWaffelsPOS.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(UserModel user)
        {
            InitializeComponent();
            string startupPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName);
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(startupPath + "/Images/header_banner.png");
            bitmap.EndInit();
            headerBanner.Source = bitmap;
            var viewModel = new MainWindowViewModel(this, user);
            DataContext = viewModel;
        }
    }
}