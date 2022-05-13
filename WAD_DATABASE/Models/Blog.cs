using System.ComponentModel.DataAnnotations;

namespace WAD_DATABASE.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }
        public string? Info { get; set; }
        public string? Readmore { get; set; }

        
    }
}
