using ConfArch.Data.Models;
using ConfArch.Data.Repositories.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ConfArch.Web.Controllers
{
    [AllowAnonymous]
    public class ConferenceController : Controller
    {
        private readonly IConferenceRepository _repo;

        public ConferenceController(IConferenceRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Organizer - Conference Overview";
            return View(await _repo.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Organizer - Add Conference";
            return View(new ConferenceModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(ConferenceModel model)
        {
            if (ModelState.IsValid)
                await _repo.Add(model);

            return RedirectToAction("Index");
        }
    }
}
