using System.ComponentModel.DataAnnotations;

namespace _02_MusicApp.Entities
{
    public class PlayList
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
