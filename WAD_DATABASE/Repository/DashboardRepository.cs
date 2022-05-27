using Microsoft.EntityFrameworkCore;
using WAD_DATABASE.Data;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Models;

namespace WAD_DATABASE.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Announcement>> GetAllUserAnnouncements()
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userAnnouncement = _context.Announcement.Where(r => r.AppUser.Id == currentUserId);
            return userAnnouncement.ToList();
        }

        public async Task<List<Blog>> GetAllUserBlogs()
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userBlog = _context.Blog.Where(r => r.AppUser.Id == currentUserId);
            return userBlog.ToList();
        }
        public async Task<AppUser> GetUserById(string id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetByIdNoTracking(string id)
        {
            return await _context.Users.Where(u => u.Id == id).AsNoTracking().FirstOrDefaultAsync();
        }

        public bool Update(AppUser user)
        {
            _context.Users.Update(user);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
