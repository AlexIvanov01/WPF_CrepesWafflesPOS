using System;
using System.Text;
using System.Windows;
using CrepesWaffelsPOS.ViewModels;
using CrepesWaffelsPOS.Models;


namespace CrepesWaffelsPOS.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow(UserModel user)
        {
                InitializeComponent();
                var viewModel = new MainWindowViewModel(this, user);
                DataContext = viewModel;
        }
    }
}