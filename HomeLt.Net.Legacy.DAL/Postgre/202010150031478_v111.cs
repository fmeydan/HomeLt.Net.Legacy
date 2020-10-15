namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Homes", "TotalTickets", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Homes", "TotalTickets", c => c.Short(nullable: false));
        }
    }
}
