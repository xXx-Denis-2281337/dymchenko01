using Dymchenko.ViewModels;

namespace Dymchenko.Views
{
    internal partial class SignUpView
    {
        internal SignUpView()
        {
            InitializeComponent();
            var signUpViewModel = new SignUpViewModel();
            DataContext = signUpViewModel;
        }
    }
}
