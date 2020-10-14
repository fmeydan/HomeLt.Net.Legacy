namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserMedias", "UserId", "dbo.Users");
            AddForeignKey("dbo.UserMedias", "UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMedias", "UserId", "dbo.Users");
            AddForeignKey("dbo.UserMedias", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
    }
}
