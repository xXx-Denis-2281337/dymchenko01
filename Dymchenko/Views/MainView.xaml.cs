using Dymchenko.ViewModels;
using System.Windows;

namespace Dymchenko.Views
{
    internal partial class MainView
    {
        private MainViewModel _mainWindowViewModel;

        internal MainView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainWindowViewModel = new MainViewModel();
            DataContext = _mainWindowViewModel;
        }
    }
}
