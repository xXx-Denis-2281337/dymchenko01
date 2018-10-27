using Dymchenko.ViewModels;

namespace Dymchenko.Views
{
    internal partial class MainView
    {
        internal MainView()
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
        }
    }
}
