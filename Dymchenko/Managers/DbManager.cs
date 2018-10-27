using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using Dymchenko.Models;

namespace Dymchenko.Managers
{
    public class DbManager
    {
        #region Additional Classes
        // representation of database
        private class Context : DbContext
        {
            public DbSet<User> Users { get; set; }
            public DbSet<Folder> Folder { get; set; }

            public Context(string name) : base(name) { }
        }
        #endregion

        #region Fields
        //sqlLite connection
        private static readonly Context _context = new Context("DefaultConnection");
        #endregion

        #region Constructors
        static DbManager() 
        {
            try
            {
                _context.Users.Load();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.ToString());
            }
        }
        #endregion

        #region Public Methods
        public static bool UserExists(string login)
        {
            return _context.Users.Any(u => u.Login == login);
        }

        public static User GetUserByLogin(string login)
        {
            return _context.Users.FirstOrDefault(u => u.Login == login);
        }

        public static void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public static void AddFolderToUserHistory(Folder folder, Guid id)
        {
            if(_context.Folder == null)
                _context.Folder.Load();

            _context.Folder.Add(folder);
            _context.SaveChanges();
        }

        public static List<Folder> GetFolderHistoryByUserId(Guid id)
        {
            if (_context.Folder != null)
                _context.Folder.Load();

            List<Folder> result = new List<Folder>();

            foreach (Folder f in _context.Folder)
            {
                if (f.UserId == id) result.Add(f);
            }

            return result;
        }

        public static void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
