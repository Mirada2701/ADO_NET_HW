using _03_Shop_CourseWork_.Entities;
using _03_Shop_CourseWork_.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Shop_CourseWork_
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Workers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=LEGION5\SQLEXPRESS;
                                        Initial Catalog = Shop;
                                        Integrated Security=True;Connect Timeout=30;
                                        Encrypt=False;Trust Server Certificate=False;
                                        Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Fluent API
            modelBuilder.Entity<Position>().Property(p => p.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Worker>().Property(w => w.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Worker>().Property(w => w.Surname).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Worker>().Property(w => w.Salary).IsRequired();
            modelBuilder.Entity<Worker>().Property(w => w.Email).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Worker>().Property(w => w.PhoneNumber).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Shop>().Property(s => s.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Shop>().Property(s => s.Address).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<City>().Property(c => c.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Country>().Property(c => c.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Product>().Property(c => c.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Product>().Property(c => c.Price).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.Discount).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.Quantity).IsRequired();
            modelBuilder.Entity<Product>().Property(c => c.IsInStock).IsRequired();

            modelBuilder.Entity<Position>()
                .HasMany(p => p.Workers)
                .WithOne(w => w.Position)
                .HasForeignKey(w => w.PositionId);
            modelBuilder.Entity<Worker>()
                .HasOne(w => w.Shop)
                .WithMany(s => s.Workers)
                .HasForeignKey(w => w.ShopId);
            modelBuilder.Entity<City>()
                .HasMany(c => c.Shops)
                .WithOne(s => s.City)
                .HasForeignKey(s => s.CityId);
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithOne(s => s.Country)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Shops)
                .WithMany(s => s.Products);

            //Seeder
            modelBuilder.SeedCategories();
            modelBuilder.SeedPositions();
            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedShops();
            modelBuilder.SeedWorkers();
            modelBuilder.SeedProducts();
        }
    }
}
