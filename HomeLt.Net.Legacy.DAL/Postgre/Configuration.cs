namespace HomeLt.Net.Legacy.DAL.Postgre
{
    using HomeLt.Net.Legacy.DAL.Static;
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
           
            if (context.District.ToList().Count == 0)
            {
                string districts = Districts.LoadDistricts();
                string cities = Cities.LoadCities();
                context.Database.ExecuteSqlCommand(cities);
                context.Database.ExecuteSqlCommand(districts);
            }

            if (context.AdminUser.FirstOrDefault(f => f.Email == "admin@homelt.com" && f.Password == "admin/homelt") == null)
            {
                context.AdminUser.Add(new ENTITIES.AdminUser { Email = "admin@homelt.com", Password = "admin/homelt" });
                    
             }

            //  This method will be called after migrating to the latest version.

                //  You can use the DbSet<T>.AddOrUpdate() helper extension method
                //  to avoid creating duplicate seed data.
        }
    }
}
