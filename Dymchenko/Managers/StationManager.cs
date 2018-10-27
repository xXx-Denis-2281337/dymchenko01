using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Dymchenko.Models;

namespace Dymchenko.Managers
{
    public static class StationManager
    {
        public static User CurrentUser { get; set; }

        //path to app data folder
        private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\Dymchenko.bin";

        public static bool CheckCurrentUserFromCache()
        {
            return File.Exists(_path);
        }

        // serialize and add user to appdata folder
        // to automatic SignIn next time
        public static void AddCurrentUserToCache()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(_path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, CurrentUser);
            stream.Close();
        }

        // loading user from appdata folder
        // and deserialize it
        public static void LoadCurrentUserFromCache()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(_path, FileMode.Open, FileAccess.Read, FileShare.Read);
            CurrentUser = (User)formatter.Deserialize(stream);
            stream.Close();
        }

        // delete serialized user from appdata folder
        // after SignOut
        public static void RemoveCurrentUserFromCache()
        {
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }
            CurrentUser = null;
        }

        internal static void CloseApp()
        {
            DbManager.Dispose();
            MessageBox.Show("ShutDown");
            Environment.Exit(1);
        }
    }
}
