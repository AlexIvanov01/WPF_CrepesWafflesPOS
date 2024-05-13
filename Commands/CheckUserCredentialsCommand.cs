using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using CrepesWaffelsPOS.Models;
using CrepesWaffelsPOS.ViewModels;
using CrepesWaffelsPOS.Views;
using Microsoft.EntityFrameworkCore;

namespace CrepesWaffelsPOS.Commands
{
    public class CheckUserCredentialsCommand : ICommand
    {
        private readonly LoginViewModel _loginViewModel;
        public CheckUserCredentialsCommand(LoginViewModel viewModel)
        {
            _loginViewModel = viewModel;
            _loginViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _loginViewModel.View.PropertyChanged += OnViewModelPropertyChanged;
        }
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return _loginViewModel.UserName != string.Empty &&
                _loginViewModel.View.Password != string.Empty;
        }

        public void Execute(object? parameter)
        {
            using(DataAccess da = new DataAccess()) 
            {
                da.Database.EnsureCreated();
                List<UserModel>Users = da.GetUsers();
                UserModel loginUser = new UserModel();
                loginUser.Username = _loginViewModel.UserName;
                loginUser.Password = _loginViewModel.View.Password;


                bool usernameExists = Users.Exists(u => u.Username == loginUser.Username);

                if (usernameExists)
                {
                    UserModel user = Users.First(u => u.Username == loginUser.Username);
                    loginUser.HashPassword();
                    if (loginUser.Password == user.Password)
                    {
                        MessageBox.Show("Access granted!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                        Window window = new MainWindow(user);
                        window.Show();
                        _loginViewModel.View.Close();
                    }
                    else
                    {
                        MessageBox.Show($"Wrong password!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show($"Username {_loginViewModel.UserName} does not exist!", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginViewModel.UserName) ||
                e.PropertyName == nameof(LoginViewModel.View.Password))
            {
                OnCanExecuteChanged();
            }
        }
    }
}
