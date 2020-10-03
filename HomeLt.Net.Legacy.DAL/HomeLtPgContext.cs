namespace HomeLt.Net.Legacy.DAL
{
    using HomeLt.Net.Legacy.ENTITIES;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HomeLtPgContext : DbContext
    {
        // Your context has been configured to use a 'HomeLtPgContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HomeLt.Net.Legacy.DAL.HomeLtPgContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HomeLtPgContext' 
        // connection string in the application configuration file.
        public HomeLtPgContext()
            : base("name=HomeLtPgContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Home> Home { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Draw> Draw { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}