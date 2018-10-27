using System.Windows.Controls;
using Dymchenko.Managers;
using Dymchenko.Tools;

namespace Dymchenko
{
    public partial class MainWindow : IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            NavigationModel navigationModel = new NavigationModel(this);

            NavigationManager.Instance.Initialize(navigationModel);

            if (StationManager.CheckCurrentUserFromCache())
            {
                StationManager.LoadCurrentUserFromCache();
                navigationModel.Navigate(ModelsEnum.Main);
            }
            else
            {
                navigationModel.Navigate(ModelsEnum.SignIn);
            }
        }

        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }
    }
}
