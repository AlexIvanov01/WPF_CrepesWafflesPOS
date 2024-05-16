using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using CrepesWaffelsPOS.Commands;
using CrepesWaffelsPOS.Components;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.Views;

namespace CrepesWaffelsPOS.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public ObservableCollection<FoodTemplate> Foods {  get; set; }
        private string _order = "Empty order list.";
        public UserModel curUser { get; set; }
        public string Username => curUser.Username;
        public double Balance => curUser.Balance;
        public ICommand OrderCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand AddFoodCommand { get; set; }
        public ICommand AddToBalanceCommand { get; set; }
        public MainWindow View { get; set; }

        public string Order
        {
            get { return _order; }
            set 
            { 
                _order = value;
                OnPropertyChanged("Order");
            }
        }


        public MainWindowViewModel(MainWindow view, UserModel user)
        {
            View = view;
            Foods = new ObservableCollection<FoodTemplate>();
            LoadFoods();
            curUser = user;
            OrderCommand = new CreateOrderCommand(this);
            LogoutCommand = new SwitchToLoginViewCommand(this);
            AddFoodCommand = new SwitchToAddFoodViewCommand(this);
            AddToBalanceCommand = new AddToBalanceCommand(this);
        }


        public void OnFoodTemplateCounterChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(FoodTemplateViewModel.Counter))
            {
                GenerateReceipt();
                OnPropertyChanged("Foods");
            }
        }

        private void LoadFoods()
        {
            try
            {
                using (DataAccess da = new DataAccess())
                {
                    var FoodsList = da.GetFoods();
                    foreach (var food in FoodsList)
                    {
                        var foodTemplate = new FoodTemplate(food);
                        foodTemplate.viewModel.PropertyChanged += OnFoodTemplateCounterChanged;
                        Foods.Add(foodTemplate);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading foods: {ex.Message}");
            }
        }

        public void GenerateReceipt()
        {
            StringBuilder receipt = new StringBuilder();
            double total = 0;
            var foodList = Foods.Where(i => i.viewModel.Counter > 0).ToList();

            if (foodList.Count != 0)
            {
                foreach (var food in foodList)
                {
                    double itemTotal = food.viewModel.Price * food.viewModel.Counter;
                    total += itemTotal;
                    receipt.Append($"{food.viewModel.Food.Name}: {food.viewModel.Food.Price}$ x {food.viewModel.Counter} = {itemTotal}$\n");
                }

                receipt.Append($"\nTotal: {total}$");

                Order = receipt.ToString();
            }
            else
            {
                Order = "Empty order list.";
            }
        }

    }
}
