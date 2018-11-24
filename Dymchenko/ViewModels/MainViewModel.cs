using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Forms;
using System.Collections.Generic;
using Dymchenko.Managers;
using Dymchenko.Models;
using Dymchenko.Properties;
using Dymchenko.Tools;
using System.Threading.Tasks;
using System;

namespace Dymchenko.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _resultText;
        private string _userText;
        private List<Folder> _history;
        #region Commands
        private ICommand _signOutCommand;
        private ICommand _chooseFolderCommand;
        private ICommand _showHistoryCommand;
        private ICommand _closeCommand;
        #endregion
        #endregion

        #region Properties
        public string ResultText
        {
            get => _resultText;
            private set
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }

        public string UserText
        {
            get => _userText;
            private set
            {
                _userText = value;
                OnPropertyChanged();
            }
        }

        public List<Folder> History
        {
            get => _history;
            private set
            {
                _history = value;
                OnPropertyChanged();
            }
        }

        #region Commands
        public ICommand SignOutCommand
        {
            get
            {
                return _signOutCommand ?? (_signOutCommand = new RelayCommand<object>(SignOutExecute));
            }
        }

        public ICommand ChooseFolderCommand
        {
            get
            {
                return _chooseFolderCommand ?? (_chooseFolderCommand = new RelayCommand<object>(ChooseFolderExecute));
            }
        }

        public ICommand ShowHistoryCommand
        {
            get
            {
                return _showHistoryCommand ?? (_showHistoryCommand = new RelayCommand<object>(ShowHistoryExecute));
            }
        }

        public ICommand CloseCommand
        {
            get
            {
                return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseExecute));
            }
        }
        #endregion
        #endregion

        #region Constructors
        internal MainViewModel()
        {
            _resultText = string.Empty;
            _userText = "Welcome " + StationManager.CurrentUser.ToString();
        }
        #endregion

        #region Private Methods
        private void SignOutExecute(object obj)
        {
            NavigationManager.Instance.Navigate(ModelsEnum.SignIn);
            Logger.Log($"\t{StationManager.CurrentUser.ToString()} succsesfuly sign out and navigated to sign in window");
            StationManager.RemoveCurrentUserFromCache();
        }

        // Async method to calculate folder size and etc.
        private async void ChooseFolderExecute(object obj)
        {
            try
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                    {
                        LoaderManager.Instance.ShowLoader();
                        Folder folder = new Folder(dialog.SelectedPath, StationManager.CurrentUser);
                        await Task.Run(() => folder.Calculate());

                        await Task.Run(() => DbManager.AddFolderToUserHistory(folder, StationManager.CurrentUser.Id));
                        ResultText = folder.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = string.Format(Resources.Main_FailedToChooseFolder, ex.Message);
                MessageBox.Show(msg);
                Logger.Log(msg, ex);
                return;
            }
            finally
            {
                LoaderManager.Instance.HideLoader();
            }     
            Logger.Log($"\t{StationManager.CurrentUser.ToString()} succsesfuly get folder info");
        }

        private async void ShowHistoryExecute(object obj)
        {
            LoaderManager.Instance.ShowLoader();
            try
            {
                await Task.Run(() => {
                    var his = DbManager.GetFolderHistoryByUserId(StationManager.CurrentUser.Id);
                    History = his;
                });
            }
            catch (Exception ex)
            {
                var msg = string.Format(Resources.Main_FailedToShowHistory, ex.Message);
                MessageBox.Show(msg);
                Logger.Log(msg, ex);
                return;
            }
            LoaderManager.Instance.HideLoader();
            Logger.Log($"\t{StationManager.CurrentUser.ToString()} was succsesfuly showen history");
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
        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        #endregion
    }
}
