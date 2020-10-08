namespace HomeLt.Net.Legacy.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
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
            
            AlterColumn("dbo.Users", "BirthDay", c => c.DateTime());
            AlterColumn("dbo.Users", "LastLogin", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyMedias", "HomeId", "dbo.Homes");
            DropIndex("dbo.PropertyMedias", new[] { "HomeId" });
            AlterColumn("dbo.Users", "LastLogin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "BirthDay", c => c.DateTime(nullable: false));
            DropTable("dbo.PropertyMedias");
        }
    }
}
