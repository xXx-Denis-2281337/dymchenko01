using System.Windows.Controls;
using Dymchenko.Managers;
using Dymchenko.Tools;
using Dymchenko.ViewModels;

namespace Dymchenko
{
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();  
            NavigationModel navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            

            StationManager.LoadCurrentUserFromCache();

            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
