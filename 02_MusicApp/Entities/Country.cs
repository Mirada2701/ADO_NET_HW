using System.ComponentModel.DataAnnotations;

namespace _02_MusicApp.Entities
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string Name { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
