using System.Data.Entity;
using DbAdapter.Migrations;
using Dymchenko.Models;

namespace DbAdapter
{
    class FolderDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Folder> Folders { get; set; }

        public FolderDbContext() : base("FolderBase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FolderDbContext, Configuration>(true));
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new User.UserEntityConfiguration());
            modelBuilder.Configurations.Add(new Folder.FolderEntityConfiguration());
        }
    }
}
