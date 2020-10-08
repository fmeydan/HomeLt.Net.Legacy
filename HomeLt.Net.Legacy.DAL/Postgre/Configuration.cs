namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HomeLt.Net.Legacy.DAL.HomeltPostgre>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Postgre";
        }

        protected override void Seed(HomeLt.Net.Legacy.DAL.HomeltPostgre context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
