using DbAdapter;
using Dymchenko.Models;
using DymchenkoFolderServiceInterface;
using System;
using System.Collections.Generic;

namespace DymchenkoFolderService
{
    class DymchenkoFolderSimulatorService : IFolderContract
    {
        public bool UserExists(string login)
        {
            return EntityWrapper.UserExists(login);
        }

        public User GetUserByLogin(string login)
        {
            return EntityWrapper.GetUserByLogin(login);
        }

        public void AddUser(User user)
        {
            EntityWrapper.AddUser(user);
        }

        public void AddFolderToUserHistory(Folder folder, Guid id)
        {
            EntityWrapper.AddFolderToUserHistory(folder, id);
        }

        public List<Folder> GetFolderHistoryByUserId(Guid id)
        {
            return EntityWrapper.GetFolderHistoryByUserId(id);
        }
    }
}
