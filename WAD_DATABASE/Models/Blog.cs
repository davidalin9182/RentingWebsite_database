using System.ComponentModel.DataAnnotations;

namespace WAD_DATABASE.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string? BlogName { get; set; }

        public string? Description { get; set; }
        public string? Image { get; set; }


    }
}
