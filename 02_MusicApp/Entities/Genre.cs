using System.ComponentModel.DataAnnotations;

namespace _02_MusicApp.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
