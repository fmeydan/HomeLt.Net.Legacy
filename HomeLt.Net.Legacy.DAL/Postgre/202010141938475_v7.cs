namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PropertyMedias", "MediaType", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PropertyMedias", "MediaType");
        }
    }
}
