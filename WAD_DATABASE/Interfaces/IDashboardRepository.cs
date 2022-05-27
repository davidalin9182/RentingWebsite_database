using WAD_DATABASE.Models;

namespace WAD_DATABASE.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Blog>> GetAllUserBlogs();
        Task<List<Announcement>> GetAllUserAnnouncements();
        Task<AppUser> GetUserById(string id);
        Task<AppUser> GetByIdNoTracking(string id);
        bool Update(AppUser user);
        bool Save();
    }
}
