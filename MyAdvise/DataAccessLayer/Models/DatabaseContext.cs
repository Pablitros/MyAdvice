using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DataAccessLayer.Models.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext() { }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Documentation> Documentation { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Premises> Premises { get; set; }
        public DbSet<BusinessFixedAssets> BusinessFixedAssets { get; set; }
        public DbSet<BusinessPremises> BusinessPremises { get; set; }
        public DbSet<BusinessWorkers> BusinessWorkers { get; set; }
        public DbSet<FixedAssets> FixedAssets { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<News> News { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Email)
                .IsUnique();

            modelBuilder.Entity<Documentation>()
                .HasOne(x => x.User)
                .GetType();

            modelBuilder.Entity<Documentation>()
                .HasOne(x => x.Business)
                .WithMany(x => x.Documentation)
                .OnDelete(DeleteBehavior.ClientSetNull);


            modelBuilder.Entity<BusinessFixedAssets>()
                .HasKey(x => new { x.FixedAssetsId, x.BusinessId });

            modelBuilder.Entity<BusinessWorkers>()
                .HasKey(x => new { x.BusinessId, x.WorkersId });

            modelBuilder.Entity<BusinessPremises>()
                .HasKey(x => new { x.BusinessId, x.PremisesId });

            modelBuilder.Entity<BusinessPremises>()
                .HasOne(x => x.Premises)
                .WithMany(x => x.BusinessPremises)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BusinessFixedAssets>()
                .HasOne(x => x.FixedAssets)
                .WithMany(x => x.BusinessFixedAssets)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<BusinessWorkers>()
                .HasOne(x => x.Workers)
                .WithMany(x => x.BusinessWorkers)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }


    }
}
