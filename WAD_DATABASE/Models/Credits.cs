using System.ComponentModel.DataAnnotations;

namespace WAD_DATABASE.Models
{
    public class Credits
    {
        [Key]
        public int Id { get; set; }
        public string Info { get; set; }
        
        
    }
}
