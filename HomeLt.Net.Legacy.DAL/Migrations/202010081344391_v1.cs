namespace HomeLt.Net.Legacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Homes", "AddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "TicketCode", c => c.String());
            CreateIndex("dbo.Homes", "AddressId");
            AddForeignKey("dbo.Homes", "AddressId", "dbo.PropertyAdresses", "PropertyAdressId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Homes", "AddressId", "dbo.PropertyAdresses");
            DropForeignKey("dbo.PropertyAdresses", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropIndex("dbo.Districts", new[] { "CityId" });
            DropIndex("dbo.PropertyAdresses", new[] { "DistrictId" });
            DropIndex("dbo.Homes", new[] { "AddressId" });
            DropColumn("dbo.Tickets", "TicketCode");
            DropColumn("dbo.Homes", "AddressId");
            DropTable("dbo.Cities");
            DropTable("dbo.Districts");
            DropTable("dbo.PropertyAdresses");
        }
    }
}
