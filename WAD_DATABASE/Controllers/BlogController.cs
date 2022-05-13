using Microsoft.AspNetCore.Mvc;
using WAD_DATABASE.Data;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Models;

namespace WAD_DATABASE.Controllers
{
    public class BlogController : Controller
    {
        
        private readonly IBlogRepository _blogRepository;
        public BlogController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> Blog = await _blogRepository.GetAll();
            return View(Blog);
        }
    }
}
