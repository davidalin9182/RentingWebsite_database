using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD_DATABASE.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string? BlogName { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }


    }
}
