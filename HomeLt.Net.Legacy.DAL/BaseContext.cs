﻿using HomeLt.Net.Legacy.ENTITIES;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<PropertyAdress> PropertyAdress { get; set; }
        public virtual DbSet<PropertyMedia> PropertyMedia { get; set; }
        public virtual DbSet<UserMedia> UserMedia { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<User>()
        //        .HasMany(e => e.UserMedias)
        //        .WithRequired(e => e.User)
        //        .WillCascadeOnDelete(false);
        //}




    }
}
