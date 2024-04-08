using _02_MusicApp.Entities;
using System.Linq;

namespace _02_MusicApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MusicAppDbContext context = new MusicAppDbContext();

            var tracksAlbum = context.Tracks.Where(t => t.AlbumId == 2 && t.Duration == "2:30");

            foreach(var track in tracksAlbum)
            {
                Console.WriteLine($"{track.Name} {track.AlbumId} {track.Duration}");
            }

            var top3 = context.Albums.Where(a => a.ArtistId == 2);
            foreach (var album in top3)
            {
                Console.WriteLine($"{album.Name} {album.ArtistId} {album.ReleaseDate}");
            }

            string name = Console.ReadLine();

            var track1 = context.Tracks.Where(t => t.Name == name);

            foreach (var track in track1)
            {
                Console.WriteLine($"{track.Name} {track.AlbumId} {track.Duration}");
            }
        }
    }
}
