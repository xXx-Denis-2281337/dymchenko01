using System;
using Dymchenko.Managers;
using Dymchenko.ViewModels;
using Dymchenko.Views;

namespace Dymchenko.Tools
{
    internal enum ModelsEnum
    {
        SignIn,
        SingUp,
        Main
    }

    internal class NavigationModel
    {
        #region Fields
        private readonly IContentWindow _contentWindow;
        private SignInView _signInView;
        private SignUpView _signUpView;
        private MainView _mainView;
        #endregion

        internal NavigationModel(IContentWindow contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal void Navigate(ModelsEnum model)
        {
            switch (model)
            {
                case ModelsEnum.SignIn:
                    _contentWindow.ContentControl.Content = _signInView ?? (_signInView = new SignInView());

                    SignInViewModel signInViewModel = _signInView.DataContext as SignInViewModel;
                    if (signInViewModel != null)
                    {
                        // if we run app and autologin (so we have already sign in earlier)
                        // and then sign out
                        // login field will be complete
                        if (StationManager.CurrentUser != null)
                        {
                            signInViewModel.Login = StationManager.CurrentUser.Login;
                        }
                        // if view model already exists
                        // clear password field
                        signInViewModel.Password = string.Empty;
                    }
                    break;
                case ModelsEnum.SingUp:
                    _contentWindow.ContentControl.Content = _signUpView ?? (_signUpView = new SignUpView());
                    _signUpView.DataContext = new SignUpViewModel();
                    break;
                case ModelsEnum.Main:
                    _contentWindow.ContentControl.Content = _mainView ?? (_mainView = new MainView());
                    _mainView.DataContext = new MainViewModel();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(model), model, null);
            }
        }
    }
}
