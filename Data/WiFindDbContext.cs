using System;
using Microsoft.EntityFrameworkCore;
using WiFind.Entities;

namespace WiFind.Data
{
    public class WiFindDbContext : DbContext
    {
        public WiFindDbContext(DbContextOptions<WiFindDbContext> options) : base(options)
        {
        }
        public DbSet<WiFindUser> WifindUsers { get; set; }
        public DbSet<Wifi> Wifis { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<WifiConnection> WifiConnections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelbuilder);
        }

    }
}

