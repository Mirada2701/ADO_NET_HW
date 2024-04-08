using _02_MusicApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_MusicApp
{
    public class MusicAppDbContext : DbContext
    {
        public MusicAppDbContext()
        {
            //this.Database.EnsureCreated();
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<PlayList> PlayLists { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"Data Source=LEGION5\SQLEXPRESS;
                                        Initial Catalog = MusicDb;
                                        Integrated Security=True;
                                        Connect Timeout=2;Encrypt=False;
                                        Trust Server Certificate=False;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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
                     Name = "Poland"
                    },
                      new Country()
                    {
                     Id = 3,
                     Name = "USA"
                    }
                });
            modelBuilder.Entity<Artist>().HasData(new Artist[]
            {
                new Artist()
                {
                Id = 1,
                First_Name = "Vitaliy",
                Last_Name = "Labenskyi",
                CountryId = 1
                },
                new Artist()
                {
                Id = 2,
                First_Name = "Brock",
                Last_Name = "Lasnar",
                CountryId = 3
                },
                 new Artist()
                {
                Id = 3,
                First_Name = "Robert",
                Last_Name = "Puszulicki",
                CountryId = 2
                },
            });
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category()
                {
                    Id = 1,
                    Name = "Algorythmic"
                },
                 new Category()
                {
                    Id = 2,
                    Name = "User"
                },
                  new Category()
                {
                    Id = 3,
                    Name = "Curator"
                }
            });
            modelBuilder.Entity<PlayList>().HasData(new PlayList[]
            {
                new PlayList()
                {
                    Id = 1,
                    Name = "My Playlist",
                    CategoryId = 2
                },
                new PlayList()
                {
                    Id = 2,
                    Name = "Rober Best",
                    CategoryId = 3
                },
                new PlayList()
                {
                    Id = 3,
                    Name = "Favorite",
                    CategoryId = 1
                },
            });
            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new Genre()
                {
                    Id = 1,
                    Name = "Rock"
                },
                new Genre()
                {
                    Id = 2,
                    Name = "Jazz"
                },
                new Genre()
                {
                    Id = 3,
                    Name = "Lyric"
                }
            });
            modelBuilder.Entity<Album>().HasData(new Album[]
            {
                new Album() 
                {
                    Id = 1,
                    Name = "Black nights",
                    ArtistId = 1,
                    ReleaseDate = new DateTime(2020,4,5),
                    GenreId= 3
                },
                new Album()
                {
                    Id = 2,
                    Name = "Rocky one",
                    ArtistId = 2,
                    ReleaseDate = new DateTime(2019,12,1),
                    GenreId= 1
                },
                new Album()
                {
                    Id = 3,
                    Name = "Package lost",
                    ArtistId = 3,
                    ReleaseDate = new DateTime(2023,5,24),
                    GenreId= 2
                }
            });
            modelBuilder.Entity<Track>().HasData(new Track[]
            {
                new Track()
                {
                    Id = 1,
                    Name = "Slava Ukraine",
                    AlbumId = 2,
                    Duration = "2:30"
                },
                new Track()
                {
                    Id = 2,
                    Name = "Plakala",
                    AlbumId = 1,
                    Duration = "2:00"
                },
                new Track()
                {
                    Id = 3,
                    Name = "Smih",
                    AlbumId = 2,
                    Duration = "1:30"
                }
            });
        }
    }
}
