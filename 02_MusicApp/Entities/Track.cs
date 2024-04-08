using System.ComponentModel.DataAnnotations;

namespace _02_MusicApp.Entities
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        [Required, MaxLength(50)]
        public string Duration { get; set; }
        public ICollection<PlayList> Playlists { get; set; }
    }
}
