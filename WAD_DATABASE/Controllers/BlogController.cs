using Microsoft.AspNetCore.Mvc;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Controllers
{
    public class BlogController : Controller
    {

        private readonly IBlogRepository _blogRepository;
        private readonly IPhotoService _photoService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BlogController(IBlogRepository blogRepository, IPhotoService photoService, IHttpContextAccessor httpContextAccessor)
        {

            _blogRepository = blogRepository;
            _photoService = photoService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Blog> Blog = await _blogRepository.GetAll();
            return View(Blog);
        }

        public IActionResult Create()
        {
            var currentUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var CreateBlogViewModel = new CreateBlogViewModel { AppUserId = currentUserId };
            return View(CreateBlogViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogViewModel BlogVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(BlogVM.Image);
                var Blog = new Blog
                {
                    BlogName = BlogVM.BlogName,
                    Description = BlogVM.Description,
                    Image = result.Url.ToString(),
                    AppUserId = BlogVM.AppUserId
                };
                _blogRepository.Add(Blog);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed!");
            }
            return View(BlogVM);

        }


        public async Task<IActionResult> Edit(int id)
        {
            var Blog = await _blogRepository.GetByIdAsync(id);
            if (Blog == null) return View("Error");
            var BlogVM = new EditBlogViewModel
            {
                BlogName = Blog.BlogName,
                Description = Blog.Description,
                URL = Blog.Image

            };
            return View(BlogVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditBlogViewModel BlogVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit blog");
                return View("Edit", BlogVM);
            }

            var userBlog = await _blogRepository.GetByIdAsyncNoTracking(id);

            if (userBlog == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(BlogVM.Image);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(BlogVM);
            }

            if (!string.IsNullOrEmpty(userBlog.Image))
            {
                _ = _photoService.DeletePhotoAsync(userBlog.Image);
            }

            var Blog = new Blog
            {
                Id = id,
                BlogName = BlogVM.BlogName,
                Description = BlogVM.Description,
                Image = photoResult.Url.ToString()
            };

            _blogRepository.Update(Blog);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Detail = await _blogRepository.GetByIdAsync(id);
            if (Detail == null) return View("Error");
            return View(Detail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var BlogDetails = await _blogRepository.GetByIdAsync(id);

            if (BlogDetails == null)
            {
                return View("Error");
            }

            _blogRepository.Delete(BlogDetails);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Blog Blog = await _blogRepository.GetByIdAsync(id);
            return View(Blog);
        }
    }
}