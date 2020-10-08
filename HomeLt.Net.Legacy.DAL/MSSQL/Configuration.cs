namespace HomeLt.Net.Legacy.DAL.MSSQL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeLt.Net.Legacy.DAL.HomeLtSql>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MSSQL";
        }

        protected override void Seed(HomeLt.Net.Legacy.DAL.HomeLtSql context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
