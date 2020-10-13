namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favorites",
                c => new
                    {
                        FavoriteId = c.Int(nullable: false, identity: true),
                        HomeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FavoriteId)
                .ForeignKey("dbo.Homes", t => t.HomeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.HomeId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.Homes", "TicketPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Homes", "BedroomNumber", c => c.Short(nullable: false));
            AddColumn("dbo.Homes", "BathNumber", c => c.Short(nullable: false));
            AddColumn("dbo.Homes", "Sqft", c => c.Short(nullable: false));
            AddColumn("dbo.Homes", "InsertDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PropertyMedias", "isDefault", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favorites", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favorites", "HomeId", "dbo.Homes");
            DropIndex("dbo.Favorites", new[] { "UserId" });
            DropIndex("dbo.Favorites", new[] { "HomeId" });
            DropColumn("dbo.Users", "Phone");
            DropColumn("dbo.PropertyMedias", "isDefault");
            DropColumn("dbo.Homes", "InsertDate");
            DropColumn("dbo.Homes", "Sqft");
            DropColumn("dbo.Homes", "BathNumber");
            DropColumn("dbo.Homes", "BedroomNumber");
            DropColumn("dbo.Homes", "TicketPrice");
            DropTable("dbo.Favorites");
        }
    }
}
