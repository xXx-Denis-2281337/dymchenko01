namespace DbAdapter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_migration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Folder", "FolderSize", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Folder", "FolderSize", c => c.Int(nullable: false));
        }
    }
}
