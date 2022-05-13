using Microsoft.AspNetCore.Mvc;
using WAD_DATABASE.Data;
using WAD_DATABASE.Interfaces;
using WAD_DATABASE.Models;
namespace WAD_DATABASE.Controllers
{
    public class CreditsController : Controller
    {
        
        private readonly ICreditsRepository _creditsRepository;
        public CreditsController(ICreditsRepository creditsRepository)
        {

            _creditsRepository = creditsRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Credits> Credits = await _creditsRepository.GetAll();
            return View(Credits);
        }
    }
}