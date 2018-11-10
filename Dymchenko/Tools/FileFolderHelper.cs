using System;
using System.IO;

namespace Dymchenko.Tools
{
    internal static class FileFolderHelper
    {
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string ClientFolderPath =
            Path.Combine(AppDataPath, "DymchenkoFolder");

        internal static readonly string LogFolderPath =
            Path.Combine(ClientFolderPath, "Log");

        internal static readonly string LogFilepath = Path.Combine(LogFolderPath,
            "App_" + DateTime.Now.ToString("dd_MM_yyyy") + ".txt");

        /*internal static readonly string StorageFilePath =
            Path.Combine(ClientFolderPath, "Storage.walsim");*/

        internal static readonly string LastUserFilePath =
            Path.Combine(ClientFolderPath, "LastUser.walsim");

        internal static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"CheckAndCreateFile failure: {filePath}", ex);
                throw;
            }
        }

        internal static bool FileExists(string path)
        {
            FileInfo file = new FileInfo(path);
            return file.Exists;
        }

        internal static void CheckAndDeleteFile(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                Logger.Log($"RemoveCurrentUser failure: {path}", ex);
                throw;
            }
        }
    }
}
