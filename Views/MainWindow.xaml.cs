using System;
using System.Text;
using System.Windows;
using CrepesWaffelsPOS.ViewModels;
using CrepesWaffelsPOS.Models;


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