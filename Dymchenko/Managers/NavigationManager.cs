using System;
using Dymchenko.Tools;

namespace Dymchenko.Managers
{
    internal class NavigationManager
    {
        #region static

        private static readonly object Lock = new object();

        private static NavigationManager _instance;

        public static NavigationManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Lock)
                {
                    return _instance = new NavigationManager();
                }
            }
        }

        internal void Navigate(object signIn)
        {
            throw new NotImplementedException();
        }
        #endregion


        private NavigationModel _navigationModel;

        internal void Initialize(NavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal void Navigate(ModelsEnum mode)
        {
            _navigationModel?.Navigate(mode);
        }
    }
}
