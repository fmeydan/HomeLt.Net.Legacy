using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLt.Net.Legacy.DAL
{
   public class BaseContext : DbContext
    {
   
        public BaseContext(string connecitonString) : base(connecitonString)
        {
          
        }

        public virtual DbSet<Home> Home { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Ticket> Ticket { get; set; }
        public virtual DbSet<Draw> Draw { get; set; }

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tickets)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);


        }
    
    }
}
