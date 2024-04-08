using System.ComponentModel.DataAnnotations;

namespace _02_MusicApp.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        [Required,MaxLength(50)]
        public string First_Name { get; set; }
        [Required, MaxLength(50)]
        public string Last_Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
