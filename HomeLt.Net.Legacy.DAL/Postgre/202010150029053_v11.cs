namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Homes", "TotalTickets", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Homes", "TotalTickets");
        }
    }
}
