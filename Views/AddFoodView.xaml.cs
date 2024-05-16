using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Views
{
    /// <summary>
    /// Interaction logic for AddFoodView.xaml
    /// </summary>
    public partial class AddFoodView : Window
    {
        public AddFoodView(MainWindowViewModel mainWindowViewModel)
        {
            InitializeComponent();
            DataContext = new AddFoodViewModel(this, mainWindowViewModel);
        }

        private void TextBox_NumericLimitTextInput(object sender, TextCompositionEventArgs e)
        {
            // Check if the entered character is a digit or a valid decimal separator
            if (!char.IsDigit(e.Text, 0) && e.Text != ".")
            {
                e.Handled = true; // Mark the event as handled to prevent the character from being entered
            }
        }
    }
}
