using Dymchenko.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DymchenkoFolderServiceInterface
{
    [ServiceContract]
    public interface IFolderContract
    {
        [OperationContract]
        bool UserExists(string login);

        [OperationContract]
        User GetUserByLogin(string login);

        [OperationContract]
        void AddUser(User user);

        [OperationContract]
        void AddFolderToUserHistory(Folder folder, Guid id);

        [OperationContract]
        List<Folder> GetFolderHistoryByUserId(Guid id);
    }
}
