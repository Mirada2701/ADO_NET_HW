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
            this.Database.EnsureCreated();
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
                                        Initial Catalog = MusicApp;
                                        Integrated Security=True;
                                        Connect Timeout=30;Encrypt=True;
                                        Trust Server Certificate=True;
                                        Application Intent=ReadWrite;
                                        Multi Subnet Failover=False");
        }
    }
    public class Artist
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
    public class Album
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
    public class Track
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public string Duration { get; set; }
        public ICollection<PlayList> Playlists { get; set; }
    }
    public class PlayList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
