namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Draws",
                c => new
                    {
                        DrawId = c.Int(nullable: false, identity: true),
                        HomeId = c.Int(nullable: false),
                        isComplated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DrawId)
                .ForeignKey("dbo.Homes", t => t.HomeId, cascadeDelete: true)
                .Index(t => t.HomeId);
            
            CreateTable(
                "dbo.Homes",
                c => new
                    {
                        HomeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoomNumber = c.Short(nullable: false),
                        PropertyType = c.Short(nullable: false),
                        UserId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        isAvaible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.HomeId)
                .ForeignKey("dbo.PropertyAdresses", t => t.AddressId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.PropertyAdresses",
                c => new
                    {
                        PropertyAdressId = c.Int(nullable: false, identity: true),
                        DistrictId = c.Int(nullable: false),
                        AddressLine1 = c.String(),
                        AddressLine2 = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.PropertyAdressId)
                .ForeignKey("dbo.Districts", t => t.DistrictId, cascadeDelete: true)
                .Index(t => t.DistrictId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        CityId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityId)
                .ForeignKey("dbo.Cities", t => t.CityId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.PropertyMedias",
                c => new
                    {
                        PropertyMediaId = c.Int(nullable: false, identity: true),
                        HomeId = c.Int(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.PropertyMediaId)
                .ForeignKey("dbo.Homes", t => t.HomeId, cascadeDelete: true)
                .Index(t => t.HomeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        BirthDay = c.DateTime(),
                        LastLogin = c.DateTime(),
                        isActive = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        DrawId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TicketCode = c.String(),
                        isWin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Draws", t => t.DrawId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DrawId)
                .Index(t => t.UserId);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Draws", "HomeId", "dbo.Homes");
            DropForeignKey("dbo.UserMedias", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "DrawId", "dbo.Draws");
            DropForeignKey("dbo.Homes", "UserId", "dbo.Users");
            DropForeignKey("dbo.PropertyMedias", "HomeId", "dbo.Homes");
            DropForeignKey("dbo.Homes", "AddressId", "dbo.PropertyAdresses");
            DropForeignKey("dbo.PropertyAdresses", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropIndex("dbo.UserMedias", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "DrawId" });
            DropIndex("dbo.PropertyMedias", new[] { "HomeId" });
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropIndex("dbo.PropertyAdresses", new[] { "DistrictId" });
            DropIndex("dbo.Homes", new[] { "AddressId" });
            DropIndex("dbo.Homes", new[] { "UserId" });
            DropIndex("dbo.Draws", new[] { "HomeId" });
            DropTable("dbo.UserMedias");
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
            DropTable("dbo.PropertyMedias");
            DropTable("dbo.Cities");
            DropTable("dbo.Districts");
            DropTable("dbo.PropertyAdresses");
            DropTable("dbo.Homes");
            DropTable("dbo.Draws");
        }
    }
}
