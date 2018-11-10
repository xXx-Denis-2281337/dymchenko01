using System;
using System.Windows;
using Dymchenko.Models;
using Dymchenko.Tools;

namespace Dymchenko.Managers
{
    internal static class StationManager
    {
        internal static User CurrentUser { get; set; }

        // serialize and add user to appdata folder
        // to automatic SignIn next time
        internal static void AddCurrentUserToCache()
        {
            SerializationManager.Serialize<User>(CurrentUser, FileFolderHelper.LastUserFilePath);
            Logger.Log($"\t{CurrentUser.ToString()} was added to auto sign in");
        }

        // loading user from appdata folder
        // and deserialize it
        internal static void LoadCurrentUserFromCache()
        {
            if (FileFolderHelper.FileExists(FileFolderHelper.LastUserFilePath)) { }
                CurrentUser = SerializationManager.Deserialize<User>(FileFolderHelper.LastUserFilePath);
            if(CurrentUser != null)
                Logger.Log($"\t{CurrentUser.ToString()} succsesfuly auto sign in");
        }

        // delete serialized user from appdata folder
        // after SignOut
        internal static void RemoveCurrentUserFromCache()
        {
            FileFolderHelper.CheckAndDeleteFile(FileFolderHelper.LastUserFilePath);
            Logger.Log($"\t{CurrentUser.ToString()} was removed from auto sign in");
            CurrentUser = null;
        }

        internal static void CloseApp()
        {
            DbManager.Dispose();
            MessageBox.Show("ShutDown");
            Logger.Log("\tSign out");
            Environment.Exit(1);
        }
    }
}
