namespace HomeLt.Net.Legacy.DAL.Migrations
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
                    })
                .PrimaryKey(t => t.HomeId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
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
                        BirthDay = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
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
                    })
                .PrimaryKey(t => t.TicketId)
                .ForeignKey("dbo.Draws", t => t.DrawId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DrawId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.Tickets", "DrawId", "dbo.Draws");
            DropForeignKey("dbo.Draws", "HomeId", "dbo.Homes");
            DropForeignKey("dbo.Homes", "UserId", "dbo.Users");
            DropIndex("dbo.Tickets", new[] { "UserId" });
            DropIndex("dbo.Tickets", new[] { "DrawId" });
            DropIndex("dbo.Homes", new[] { "UserId" });
            DropIndex("dbo.Draws", new[] { "HomeId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Users");
            DropTable("dbo.Homes");
            DropTable("dbo.Draws");
        }
    }
}
