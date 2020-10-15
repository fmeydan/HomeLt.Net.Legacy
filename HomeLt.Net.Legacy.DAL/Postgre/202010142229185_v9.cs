namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "DrawId", "dbo.Draws");
            DropForeignKey("dbo.Draws", "HomeId", "dbo.Homes");
            DropIndex("dbo.Draws", new[] { "HomeId" });
            DropIndex("dbo.Tickets", new[] { "DrawId" });
            AddColumn("dbo.Tickets", "HomeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "HomeId");
            AddForeignKey("dbo.Tickets", "HomeId", "dbo.Homes", "HomeId", cascadeDelete: true);
            DropColumn("dbo.Tickets", "DrawId");
            DropTable("dbo.Draws");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Draws",
                c => new
                    {
                        DrawId = c.Int(nullable: false, identity: true),
                        HomeId = c.Int(nullable: false),
                        isComplated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DrawId);
            
            AddColumn("dbo.Tickets", "DrawId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Tickets", "HomeId", "dbo.Homes");
            DropIndex("dbo.Tickets", new[] { "HomeId" });
            DropColumn("dbo.Tickets", "HomeId");
            CreateIndex("dbo.Tickets", "DrawId");
            CreateIndex("dbo.Draws", "HomeId");
            AddForeignKey("dbo.Draws", "HomeId", "dbo.Homes", "HomeId", cascadeDelete: true);
            AddForeignKey("dbo.Tickets", "DrawId", "dbo.Draws", "DrawId", cascadeDelete: true);
        }
    }
}
