namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Homes", "SoldTicket", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Testimonals", "UserId", "dbo.Users");
            DropIndex("dbo.Testimonals", new[] { "UserId" });
            DropColumn("dbo.Homes", "SoldTicket");
            DropTable("dbo.Testimonals");
        }
    }
}
