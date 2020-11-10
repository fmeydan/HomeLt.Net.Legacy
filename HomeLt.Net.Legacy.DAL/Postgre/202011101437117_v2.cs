namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserMedias", "MediaType", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserMedias", "MediaType");
        }
    }
}
