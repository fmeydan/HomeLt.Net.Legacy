namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMedias", "UserId", "dbo.Users");
            AddForeignKey("dbo.UserMedias", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMedias", "UserId", "dbo.Users");
            AddForeignKey("dbo.UserMedias", "UserId", "dbo.Users", "UserId");
        }
    }
}
