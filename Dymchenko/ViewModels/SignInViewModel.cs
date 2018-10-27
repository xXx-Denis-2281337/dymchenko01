using Dymchenko.Managers;
using Dymchenko.Models;
using Dymchenko.Properties;
using Dymchenko.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Dymchenko.ViewModels
{
    internal class SignInViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _password;
        private string _login;

        #region Commands
        private ICommand _closeCommand;
        private ICommand _signInCommand;
        private ICommand _signUpCommand;
        #endregion
        #endregion

        #region Properties
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }
        #region Commands

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }

        public ICommand SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute, SignInCanExecute));
            }
        }

        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute));
            }
        }

        #endregion
        #endregion

        #region Private Methods
        private void SignUpExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModelsEnum.SingUp);
        }

        private void SignInExecute(object obj)
        {
            User currentUser;
            try
            {
                currentUser = DbManager.GetUserByLogin(_login);
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.SignIn_FailedToGetUser, Environment.NewLine, ex.Message));
                return;
            }
            if (currentUser == null)
            {
                MessageBox.Show(String.Format(Resources.SignIn_UserDoesntExist, _login));
                return;
            }
            try
            {
                if (!currentUser.CheckPassword(_password))
                {
                    MessageBox.Show(Resources.SignIn_WrongPassword);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format(Resources.SignIn_FailedToValidatePassword, Environment.NewLine, ex.Message));
                return;
            }
            StationManager.CurrentUser = currentUser;
            StationManager.AddCurrentUserToCache();
            NavigationManager.Instance.Navigate(ModelsEnum.Main);
        }

        private bool SignInCanExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_login) && !string.IsNullOrWhiteSpace(_password);
        }

        private void CloseExecute(object obj)
        {
            StationManager.CloseApp();
        }
        #endregion

        #region EventsAndHandlers
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
