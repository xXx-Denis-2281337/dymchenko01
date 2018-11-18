using DbAdapter;
using Dymchenko.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DbAdapter
{
    public class EntityWrapper
    {
        #region Public Methods
        public static bool UserExists(string login)
        {
            using (var context = new FolderDbContext())
            {
                return context.Users.Any(u => u.Login == login);
            }
        }

        public static User GetUserByLogin(string login)
        {
            using (var context = new FolderDbContext())
            {
                return context.Users.FirstOrDefault(u => u.Login == login);
            }
        }

        public static void AddUser(User user)
        {
            using (var context = new FolderDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void AddFolderToUserHistory(Folder folder, Guid id)
        {
            using (var context = new FolderDbContext())
            {
                context.Folders.Add(folder);
                context.SaveChanges();
            }
                
        }

        public static List<Folder> GetFolderHistoryByUserId(Guid id)
        {
            using (var context = new FolderDbContext())
            {
                List<Folder> result = new List<Folder>();

                foreach (Folder f in context.Folders)
                {
                    if (f.UserId == id) result.Add(f);
                }

                return result;
            }
        }
        #endregion

    }
}
