using System.ComponentModel.DataAnnotations;

namespace _02_MusicApp.Entities
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(100)]
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
