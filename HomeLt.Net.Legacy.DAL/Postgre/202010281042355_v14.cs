namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v14 : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminUsers");
        }
    }
}
