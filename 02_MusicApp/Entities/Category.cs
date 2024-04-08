using System.ComponentModel.DataAnnotations;

namespace _02_MusicApp.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        public ICollection<PlayList> PlayLists { get; set; }
    }
}
