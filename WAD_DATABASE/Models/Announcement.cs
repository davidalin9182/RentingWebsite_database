using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WAD_DATABASE.Data.Enum;

namespace WAD_DATABASE.Models
{
    public class Announcement
    {
        [Key]
        public int Id { get; set; }
        public string? AnnouncementName { get; set; }
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public string? Location { get; set; }

        public string? PropertyType { get; set; }
        public int? Price { get; set; }

        public int? Phone { get; set; }

        public int? Surface { get; set; }

        

      
    }
}
