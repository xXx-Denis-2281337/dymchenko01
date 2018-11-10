using Dymchenko.ViewModels;
using System.Windows;

namespace Dymchenko.Views
{
    internal partial class MainView
    {
        private MainViewModel _mainWindowViewModel;
        //private WalletConfigurationView _currentWalletConfigurationView;

        internal MainView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainWindowViewModel = new MainViewModel();
            //_mainWindowViewModel.WalletChanged += OnWalletChanged;
            DataContext = _mainWindowViewModel;
        }
    }
}
