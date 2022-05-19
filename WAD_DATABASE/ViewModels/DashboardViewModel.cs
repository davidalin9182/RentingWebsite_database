using WAD_DATABASE.Models;

namespace WAD_DATABASE.ViewModels
{
    public class DashboardViewModel
    {
        public List<Blog> Blog { get; set; }
        public List<Announcement> Announcement { get; set; }
    }
}
