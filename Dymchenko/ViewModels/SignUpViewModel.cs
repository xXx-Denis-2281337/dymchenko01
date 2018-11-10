using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Dymchenko.Managers;
using Dymchenko.Models;
using Dymchenko.Properties;
using Dymchenko.Tools;

namespace Dymchenko.ViewModels
{
    internal class SignUpViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _password;
        private string _login;
        private string _firstName;
        private string _lastName;
        private string _email;
        #region Commands
        private ICommand _closeCommand;
        private ICommand _signUpCommand;
        private ICommand _signInCommand;
        #endregion
        #endregion

        #region Properties
        #region Command

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }

        public ICommand SignUpCommand
        {
            get
            {
                return _signUpCommand ?? (_signUpCommand = new RelayCommand<object>(SignUpExecute, SignUpCanExecute));
            }
        }
        public ICommand SignInCommand
        {
            get
            {
                return _signInCommand ?? (_signInCommand = new RelayCommand<object>(SignInExecute));
            }
        }
        #endregion

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

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Private Methods
        private async void SignUpExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    if (!new EmailAddressAttribute().IsValid(_email))
                    {
                        var msg = string.Format(Resources.SignUp_EmailIsNotValid, _email);
                        MessageBox.Show(msg);
                        Logger.Log(msg);
                        return false;
                    }
                    if (DbManager.UserExists(_login))
                    {
                        var msg = string.Format(Resources.SignUp_UserAlreadyExists, _login);
                        MessageBox.Show(msg);
                        Logger.Log(msg);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    var msg = string.Format(Resources.SignUp_FailedToValidateData, Environment.NewLine, ex.Message);
                    MessageBox.Show(msg);
                    Logger.Log(msg);
                    return false;
                }
                try
                {
                    var user = new User(_firstName, _lastName, _email, _login, _password);
                    DbManager.AddUser(user);
                    StationManager.CurrentUser = user;
                }
                catch (Exception ex)
                {
                    var msg = string.Format(Resources.SignUp_FailedToCreateUser, Environment.NewLine, ex.Message);
                    MessageBox.Show(msg);
                    Logger.Log(msg);
                    return false;
                }
                MessageBox.Show(string.Format(Resources.SignUp_UserSuccessfulyCreated, _login));
                return true;
            });
            LoaderManager.Instance.HideLoader();
            if(result)
            {
                StationManager.AddCurrentUserToCache();
                NavigationManager.Instance.Navigate(ModelsEnum.Main);
                Logger.Log($"\t{StationManager.CurrentUser.ToString()} succesfuly sign in and navigated to main window");
            }
        }

        private bool SignUpCanExecute(object obj)
        {
            return !string.IsNullOrWhiteSpace(_login) && 
                   !string.IsNullOrWhiteSpace(_password) &&
                   !string.IsNullOrWhiteSpace(_firstName) &&
                   !string.IsNullOrWhiteSpace(_lastName) &&
                   !string.IsNullOrWhiteSpace(_email);
        }

        private void SignInExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModelsEnum.SignIn);
            Logger.Log($"\t Client navigated from sign up window to sign in window");
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
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
