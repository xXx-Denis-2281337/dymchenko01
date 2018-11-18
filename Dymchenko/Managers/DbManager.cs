using System;
using System.Collections.Generic;
using Dymchenko.Models;

namespace Dymchenko.Managers
{
    public class DbManager
    {
        #region Public Methods
        public static bool UserExists(string login)
        {
            return DbAdapter.EntityWrapper.UserExists(login);
        }

        public static User GetUserByLogin(string login)
        {
            return DbAdapter.EntityWrapper.GetUserByLogin(login);
        }

        public static void AddUser(User user)
        {
            DbAdapter.EntityWrapper.AddUser(user);
        }

        public static void AddFolderToUserHistory(Folder folder, Guid id)
        {
             DbAdapter.EntityWrapper.AddFolderToUserHistory(folder, id);
        }

        public static List<Folder> GetFolderHistoryByUserId(Guid id)
        {
            return DbAdapter.EntityWrapper.GetFolderHistoryByUserId(id);
        }
        #endregion
    }
}
