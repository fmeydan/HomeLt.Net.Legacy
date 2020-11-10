namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminUsers",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        Email = c.String(maxLength: 50),
                        Password = c.String(maxLength: 24),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        InsertDate = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Districts",
                c => new
                    {
                        DistrictId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DistrictId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Homes",
                c => new
                    {
                        HomeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TicketPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoomNumber = c.Short(nullable: false),
                        BedroomNumber = c.Short(nullable: false),
                        BathNumber = c.Short(nullable: false),
                        Sqft = c.Short(nullable: false),
                        PropertyType = c.Short(nullable: false),
                        UserId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                        isAvaible = c.Boolean(nullable: false),
                        InsertDate = c.DateTime(nullable: false),
                        UpdateTime = c.DateTime(),
                        BuildingAge = c.Short(nullable: false),
                        Parking = c.Boolean(nullable: false),
                        CentralHeating = c.Boolean(nullable: false),
                        ExcerciseRoom = c.Boolean(nullable: false),
                        SellingType = c.Boolean(nullable: false),
                        isApproved = c.Boolean(nullable: false),
                        TotalTickets = c.Int(nullable: false),
                        SoldTicket = c.Int(nullable: false),
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
                "dbo.PropertyMedias",
                c => new
                    {
                        PropertyMediaId = c.Int(nullable: false, identity: true),
                        HomeId = c.Int(nullable: false),
                        Path = c.String(),
                        isDefault = c.Boolean(nullable: false),
                        MediaType = c.Short(nullable: false),
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
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        BirthDay = c.DateTime(),
                        LastLogin = c.DateTime(),
                        isActive = c.Boolean(nullable: false),
                        ActivationCode = c.Guid(nullable: false),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
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
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TicketId = c.Int(nullable: false, identity: true),
                        HomeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        TicketCode = c.String(),
                        isWin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Homes", t => t.HomeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.HomeId)
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
            
            CreateTable(
                "dbo.Testimonals",
                c => new
                    {
                        TestimonalId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TestimonalDescription = c.String(),
                    })
                .PrimaryKey(t => t.TestimonalId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Testimonals", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserMedias", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "HomeId", "dbo.Homes");
            DropForeignKey("dbo.Homes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favorites", "UserId", "dbo.Users");
            DropForeignKey("dbo.Favorites", "HomeId", "dbo.Homes");
            DropForeignKey("dbo.PropertyMedias", "HomeId", "dbo.Homes");
            DropForeignKey("dbo.Homes", "AddressId", "dbo.PropertyAdresses");
            DropForeignKey("dbo.PropertyAdresses", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropIndex("dbo.Testimonals", new[] { "UserId" });
            DropIndex("dbo.UserMedias", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "HomeId" });
            DropIndex("dbo.Favorites", new[] { "UserId" });
            DropIndex("dbo.Favorites", new[] { "HomeId" });
            DropIndex("dbo.PropertyMedias", new[] { "HomeId" });
            DropIndex("dbo.PropertyAdresses", new[] { "DistrictId" });
            DropIndex("dbo.Homes", new[] { "AddressId" });
            DropIndex("dbo.Homes", new[] { "UserId" });
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropTable("dbo.Testimonals");
            DropTable("dbo.UserMedias");
            DropTable("dbo.Tickets");
            DropTable("dbo.Favorites");
            DropTable("dbo.Users");
            DropTable("dbo.PropertyMedias");
            DropTable("dbo.PropertyAdresses");
            DropTable("dbo.Homes");
            DropTable("dbo.Districts");
            DropTable("dbo.Cities");
            DropTable("dbo.AdminUsers");
        }
    }
}
