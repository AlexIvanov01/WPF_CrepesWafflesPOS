using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.Views;
using CrepesWaffelsPOS.ViewModels;

namespace CrepesWaffelsPOS.Commands
{
    public class CreateUserToDataBaseCommand : ICommand
    {
        private readonly RegisterViewModel _registerViewModel;

        public CreateUserToDataBaseCommand(RegisterViewModel viewModel)
        {
            _registerViewModel = viewModel;
            _registerViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _registerViewModel.View.PropertyChanged += OnViewModelPropertyChanged;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _registerViewModel.UserName != string.Empty &&
                _registerViewModel.View.Password != string.Empty;
        }

        public void Execute(object? parameter)
        {
            UserModel newUser = new UserModel(_registerViewModel.UserName,
                _registerViewModel.View.Password, _registerViewModel.Balance);

            newUser.HashPassword();

          //  MessageBox.Show($"{newUser.Username} + {newUser.Password} + {newUser.Balance}");

            using (DataAccess da = new DataAccess())
            {
                da.Database.EnsureCreated();
                var users = new List<UserModel>(da.GetUsers());
                bool usernameExists = users.Exists(user => user.Username == newUser.Username);
                if (usernameExists)
                {
                    MessageBox.Show($"User with user name {newUser.Username} already exists.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    da.AddUser(newUser);
                    MessageBox.Show($"User {newUser.Username} created.");
                    Window window = new MainWindow(newUser);
                    window.Show();
                    _registerViewModel.View.Close();
                }
            }
        }

        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegisterViewModel.UserName) ||
                e.PropertyName == nameof(RegisterViewModel.View.Password))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
