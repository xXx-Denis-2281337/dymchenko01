using Dymchenko.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace DymchenkoFolderServiceInterface
{
    public class FolderServiceWrapper
    {
        public static bool UserExists(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IFolderContract>("Server"))
            {
                IFolderContract client = myChannelFactory.CreateChannel();
                return client.UserExists(login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var myChannelFactory = new ChannelFactory<IFolderContract>("Server"))
            {
                IFolderContract client = myChannelFactory.CreateChannel();
                return client.GetUserByLogin(login);
            }
        }

        public static void AddUser(User user)
        {
            using (var myChannelFactory = new ChannelFactory<IFolderContract>("Server"))
            {
                IFolderContract client = myChannelFactory.CreateChannel();
                client.AddUser(user);
            }
        }

        public static void AddFolderToUserHistory(Folder folder, Guid id)
        {
            using (var myChannelFactory = new ChannelFactory<IFolderContract>("Server"))
            {
                IFolderContract client = myChannelFactory.CreateChannel();
                client.AddFolderToUserHistory(folder, id);
            }
        }

        public static List<Folder> GetFolderHistoryByUserId(Guid id)
        {
            using (var myChannelFactory = new ChannelFactory<IFolderContract>("Server"))
            {
                IFolderContract client = myChannelFactory.CreateChannel();
                return client.GetFolderHistoryByUserId(id);
            }
        }
    }
}
