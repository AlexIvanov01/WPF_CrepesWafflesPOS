using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CrepesWaffelsPOS.ViewModels;
using CrepesWaffelsPOS.Models;
using Microsoft.EntityFrameworkCore;

namespace CrepesWaffelsPOS.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using (DataAccess da = new DataAccess())
            {
                da.Database.EnsureCreated();
                InitializeComponent();
                var viewModel = new MainWindowViewModel(da);
                DataContext = viewModel;
            }
        }
    }
}