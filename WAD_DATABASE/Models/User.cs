using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WAD_DATABASE.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string? Name { get; set; }

        public ICollection<Announcement>? Game { get; set; }

        public ICollection<Score>? Score { get; set; }

    }
}
