namespace HomeLt.Net.Legacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserMedias",
                c => new
                    {
                        UserMediaId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.UserMediaId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Homes", "isAvaible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "isWin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMedias", "UserId", "dbo.Users");
            DropIndex("dbo.UserMedias", new[] { "UserId" });
            DropColumn("dbo.Tickets", "isWin");
            DropColumn("dbo.Homes", "isAvaible");
            DropTable("dbo.UserMedias");
        }
    }
}
