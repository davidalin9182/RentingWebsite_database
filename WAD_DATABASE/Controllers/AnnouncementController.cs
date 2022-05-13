using Microsoft.AspNetCore.Mvc;
using WAD_DATABASE.Data;
using WAD_DATABASE.Models;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.ViewModels;

namespace WAD_DATABASE.Controllers
{
    public class AnnouncementController : Controller
    {
        
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IPhotoService _photoService;
        public AnnouncementController(IAnnouncementRepository announcementRepository, IPhotoService photoService)
        {

            _announcementRepository = announcementRepository;
            _photoService = photoService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Announcement> Announcement = await _announcementRepository.GetAll();
            return View(Announcement);
        }

        public IActionResult Create()
        {
            return View();
        }
            
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnnouncementViewModel announcementViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _photoService.AddPhotoAsync(announcementViewModel.Image);
                var Announcement = new Announcement
                {
                    AnnouncementName = announcementViewModel.AnnouncementName,
                    Description = announcementViewModel.Description,
                    Image = result.Url.ToString()
                };
                _announcementRepository.Add(Announcement);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo Upload Failed!");
            }
            return View(announcementViewModel);
           
        }

       
        public async Task<IActionResult> Edit(int id)
        {
            var Announcement = await _announcementRepository.GetByIdAsync(id);
            if (Announcement == null) return View("Error");
            var AnnouncementVM = new EditAnnouncementViewModel
            {
                AnnouncementName = Announcement.AnnouncementName,
                Description = Announcement.Description,
                URL = Announcement.Image
                
            };
            return View(AnnouncementVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditAnnouncementViewModel AnnouncementVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit announcement");
                return View("Edit", AnnouncementVM);
            }

            var userAnnouncement = await _announcementRepository.GetByIdAsyncNoTracking(id);

            if (userAnnouncement == null)
            {
                return View("Error");
            }

            var photoResult = await _photoService.AddPhotoAsync(AnnouncementVM.Image);

            if (photoResult.Error != null)
            {
                ModelState.AddModelError("Image", "Photo upload failed");
                return View(AnnouncementVM);
            }

            if (!string.IsNullOrEmpty(userAnnouncement.Image))
            {
                _ = _photoService.DeletePhotoAsync(userAnnouncement.Image);
            }

            var Announcement = new Announcement
            {
                Id = id,
                AnnouncementName = AnnouncementVM.AnnouncementName,
                Description = AnnouncementVM.Description,
                Image = photoResult.Url.ToString()
            };

            _announcementRepository.Update(Announcement);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Detail = await _announcementRepository.GetByIdAsync(id);
            if (Detail == null) return View("Error");
            return View(Detail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var AnnouncementDetails = await _announcementRepository.GetByIdAsync(id);

            if (AnnouncementDetails == null)
            {
                return View("Error");
            }

            _announcementRepository.Delete(AnnouncementDetails);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int id)
        {
            Announcement Announcement = await _announcementRepository.GetByIdAsync(id);
            return View(Announcement);
        }
    }
}