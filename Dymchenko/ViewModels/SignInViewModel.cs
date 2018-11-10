using Dymchenko.Managers;
using Dymchenko.Models;
using Dymchenko.Properties;
using Dymchenko.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
            Logger.Log($"\t Client navigated from sign window in to sign up window");
        }

        private async void SignInExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                User currentUser;
                try
                {
                    currentUser = DbManager.GetUserByLogin(_login);
                }
                catch (Exception ex)
                {
                    var msg = string.Format(Resources.SignIn_FailedToGetUser, Environment.NewLine, ex.Message);
                    MessageBox.Show(msg);
                    Logger.Log(msg);
                    return false;
                }
                if (currentUser == null)
                {
                    var msg = string.Format(Resources.SignIn_UserDoesntExist, _login);
                    MessageBox.Show(msg);
                    Logger.Log(msg);
                    return false;
                }
                try
                {
                    if (!currentUser.CheckPassword(_password))
                    {
                        MessageBox.Show(Resources.SignIn_WrongPassword);
                        Logger.Log(Resources.SignIn_WrongPassword);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    var msg = string.Format(Resources.SignIn_FailedToValidatePassword, Environment.NewLine, ex.Message);
                    MessageBox.Show(msg);
                    Logger.Log(msg);
                    return false;
                }
                StationManager.CurrentUser = currentUser;
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if (result)
            {
                StationManager.AddCurrentUserToCache();
                NavigationManager.Instance.Navigate(ModelsEnum.Main);
                Logger.Log($"\t{StationManager.CurrentUser.ToString()} succsesfuly sign in and navigated to main window");
            }
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
