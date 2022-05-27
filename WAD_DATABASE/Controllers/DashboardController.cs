using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Models;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRespository;
        private readonly IPhotoService _photoService;



        public DashboardController(IDashboardRepository dashboardRespository, IPhotoService photoService)
        {
            _dashboardRespository = dashboardRespository;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var userBlog = await _dashboardRespository.GetAllUserBlogs();
            var userAnnouncement = await _dashboardRespository.GetAllUserAnnouncements();
            var dashboardViewModel = new DashboardViewModel()
            {
                Blog = userBlog,
                Announcement = userAnnouncement
            };
            return View(dashboardViewModel);
        }
    }
}