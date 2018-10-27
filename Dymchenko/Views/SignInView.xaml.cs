using Dymchenko.ViewModels;

namespace Dymchenko.Views
{
    internal partial class SignInView
    {
        internal SignInView()
        {
            InitializeComponent();
            SignInViewModel signInViewModel = new SignInViewModel();
            DataContext = signInViewModel;
        }
    }
}
