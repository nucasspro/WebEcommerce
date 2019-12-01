using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using WebEcommerce.Data.EF.EntityConfigurations;
using WebEcommerce.Data.EF.Extensions;
using WebEcommerce.Data.Entities;
using WebEcommerce.Model.Interfaces;
using WebEcommerce.Utility.Helpers;

namespace WebEcommerce.Data.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BillDetail> BillDetails { set; get; }
        public DbSet<Bill> Bills { set; get; }
        public DbSet<Category> Categories { set; get; }
        public DbSet<Color> Colors { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<ProductImage> ProductImages { set; get; }
        public DbSet<ProductQuantity> ProductQuantities { set; get; }
        public DbSet<Size> Sizes { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(GetConnection.GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new BillConfiguration());
            modelBuilder.AddConfiguration(new BillDetailConfiguration());
            modelBuilder.AddConfiguration(new CategoryConfiguration());
            modelBuilder.AddConfiguration(new ColorConfiguration());
            modelBuilder.AddConfiguration(new ProductConfiguration());
            modelBuilder.AddConfiguration(new ProductImageConfiguration());
            modelBuilder.AddConfiguration(new ProductQuantityConfiguration());
            modelBuilder.AddConfiguration(new SizeConfiguration());
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);

            foreach (EntityEntry item in modified)
            {
                if (item.Entity is IDateTracking changedOrAddedItem)
                {
                    if (item.State == EntityState.Added)
                    {
                        changedOrAddedItem.DateCreated = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);
                    }
                    changedOrAddedItem.DateModified = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);
                }
            }
            return base.SaveChanges();
        }
    }

    public static class GetConnection
    {
        public static string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            return configuration.GetConnectionString("DefaultConnection"); ;
        }
    }
}