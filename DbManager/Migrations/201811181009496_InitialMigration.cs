namespace DbAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Folder",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Path = c.String(nullable: false),
                        FilesCount = c.Int(nullable: false),
                        FoldersCount = c.Int(nullable: false),
                        FolderSize = c.Int(nullable: false),
                        FolderRequestDate = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        LastLoginDate = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folder", "UserId", "dbo.Users");
            DropIndex("dbo.Folder", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Folder");
        }
    }
}
