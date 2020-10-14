namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropForeignKey("dbo.PropertyAdresses", "DistrictId", "dbo.Districts");
            DropPrimaryKey("dbo.Districts");
            AddColumn("dbo.Districts", "DistrictId", c => c.Int(nullable: true, identity: true));
            AddColumn("dbo.Homes", "BuildingAge", c => c.Short(nullable: false));
            AddColumn("dbo.Homes", "Parking", c => c.Boolean(nullable: false));
            AddColumn("dbo.Homes", "CentralHeating", c => c.Boolean(nullable: false));
            AddColumn("dbo.Homes", "ExcerciseRoom", c => c.Boolean(nullable: false));
            AddColumn("dbo.Homes", "SellingType", c => c.Boolean(nullable: false));
            AddPrimaryKey("dbo.Districts", "DistrictId");
            AddForeignKey("dbo.Districts", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
            AddForeignKey("dbo.PropertyAdresses", "DistrictId", "dbo.Districts", "DistrictId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PropertyAdresses", "DistrictId", "dbo.Districts");
            DropForeignKey("dbo.Districts", "CityId", "dbo.Cities");
            DropPrimaryKey("dbo.Districts");
            DropColumn("dbo.Homes", "SellingType");
            DropColumn("dbo.Homes", "ExcerciseRoom");
            DropColumn("dbo.Homes", "CentralHeating");
            DropColumn("dbo.Homes", "Parking");
            DropColumn("dbo.Homes", "BuildingAge");
            DropColumn("dbo.Districts", "DistrictId");
            AddPrimaryKey("dbo.Districts", "CityId");
            AddForeignKey("dbo.PropertyAdresses", "DistrictId", "dbo.Districts", "CityId", cascadeDelete: true);
            AddForeignKey("dbo.Districts", "CityId", "dbo.Cities", "CityId");
        }
    }
}
