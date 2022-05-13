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

        public string? Description { get; set; }
        public string? Image { get; set; }

      
    }
}
