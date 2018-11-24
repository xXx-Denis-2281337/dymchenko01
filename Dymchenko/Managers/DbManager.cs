using System;
using System.Collections.Generic;
using Dymchenko.Models;
using DymchenkoFolderServiceInterface;

namespace Dymchenko.Managers
{
    public class DbManager
    {
        #region Public Methods
        public static bool UserExists(string login)
        {
            return FolderServiceWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return FolderServiceWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            FolderServiceWrapper.AddUser(user);
        }

        public static void AddFolderToUserHistory(Folder folder, Guid id)
        {
            FolderServiceWrapper.AddFolderToUserHistory(folder, id);
        }

        public static List<Folder> GetFolderHistoryByUserId(Guid id)
        {
            return FolderServiceWrapper.GetFolderHistoryByUserId(id);
        }
        #endregion
    }
}
