using _03_Shop_CourseWork_.Entities;
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
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category()
                {
                    Id = 1,
                    Name = "Vegetables"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Fruits"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Grains"
                }
            });
            modelBuilder.Entity<Position>().HasData(new Position[]
            {
                new Position()
                {
                    Id = 1,
                    Name = "Director"
                },
                new Position()
                {
                    Id = 2,
                    Name = "Manager"
                },
                new Position()
                {
                    Id = 3,
                    Name = "Cashier"
                }
            });
            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country()
                {
                    Id = 1,
                    Name = "Ukraine"
                },
                new Country()
                {
                    Id = 2,
                    Name = "Usa"
                },
                new Country()
                {
                    Id = 3,
                    Name = "Poland"
                }
            });
            modelBuilder.Entity<City>().HasData(new City[]
            {
                new City()
                {
                    Id = 1,
                    Name = "Kyiv",
                    CountryId = 1
                },
                new City()
                {
                    Id = 2,
                    Name = "Kharkiv",
                    CountryId = 1
                },
                new City()
                {
                    Id = 3,
                    Name = "Warshav",
                    CountryId = 3
                },
                new City()
                {
                    Id = 4,
                    Name = "New-York",
                    CountryId = 2
                },
                new City()
                {
                    Id = 5,
                    Name = "Chikago",
                    CountryId = 2
                },
                new City()
                {
                    Id = 6,
                    Name = "Rivne",
                    CountryId = 1
                },
                new City()
                {
                    Id = 7,
                    Name = "Krakiw",
                    CountryId = 3
                },
                new City()
                {
                    Id = 8,
                    Name = "Dallas",
                    CountryId = 2
                }
            });
            modelBuilder.Entity<Shop>().HasData(new Shop[]
            {
                new Shop()
                {
                    Id = 1,
                    Name = "Koshuk",
                    Address = "Rivnenska 107",
                    CityId = 1,
                    ParkingArea = 5
                },
                new Shop()
                {
                    Id = 2,
                    Name = "Khameleon",
                    Address = "Sydorova 11a",
                    CityId = 2,
                    ParkingArea = 4
                },
                new Shop()
                {
                    Id = 3,
                    Name = "Market",
                    Address = "Stysa 14",
                    CityId = 3,
                    ParkingArea = 2
                }
            });
            modelBuilder.Entity<Worker>().HasData(new Worker[]
            {
                new Worker()
                {
                    Id = 1,
                    Name = "Vitaliy",
                    Surname = "Romanov",
                    Salary = 15000,
                    Email = "vitaliy-24@ukr.net",
                    PhoneNumber = "380965740762",
                    PositionId = 3,
                    ShopId = 1
                },
                new Worker()
                {
                    Id = 2,
                    Name = "Roman",
                    Surname = "Litvinko",
                    Salary = 26000,
                    Email = "roma-25@ukr.net",
                    PhoneNumber = "380969830762",
                    PositionId = 2,
                    ShopId = 1
                },
                new Worker()
                {
                    Id = 3,
                    Name = "Natalia",
                    Surname = "Labenska",
                    Salary = 40000,
                    Email = "nat-25@ukr.net",
                    PhoneNumber = "380329830762",
                    PositionId = 1,
                    ShopId = 1
                }
            });
            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product()
                {
                    Id = 1,
                    Name = "Tomato",
                    Price = 25,
                    Discount = 10,
                    CategoryId = 1,
                    Quantity = 100,
                    IsInStock = true
                },
                new Product()
                {
                    Id = 2,
                    Name = "Bread",
                    Price = 15,
                    Discount = 5,
                    CategoryId = 3,
                    Quantity = 40,
                    IsInStock = true
                },
                new Product()
                {
                    Id = 3,
                    Name = "Apple",
                    Price = 12,
                    Discount = 1,
                    CategoryId = 2,
                    Quantity = 50,
                    IsInStock = true
                },
                new Product()
                {
                    Id = 4,
                    Name = "Cucumber",
                    Price = 50,
                    Discount = 25,
                    CategoryId = 1,
                    Quantity = 0,
                    IsInStock = false
                }
            });
        }
    }
}
