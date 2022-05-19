using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WAD_DATABASE.Models;

namespace WAD_DATABASE.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Login> Login { get; set; }
        public DbSet<Register> Register { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Credits> Credits { get; set; }
        public DbSet<Announcement> Announcement { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<Score> Score { get; set; }
    }
}
