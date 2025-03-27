using CandidateProfileSystem.Models;
using CandidateProfileSystem.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CandidateProfileSystem.Controllers
{
    public class TechnologyController : Controller
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyController(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        // Display all technologies
        public async Task<IActionResult> Index()
        {
            var technologies = await _technologyRepository.GetAllAsync();
            return View(technologies);
        }

        // Display Create form
        public IActionResult Create()
        {
            return View();
        }

        // Handle Create form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Technology technology)
        {
            if (!ModelState.IsValid)
            {
                return View(technology);
            }

            await _technologyRepository.AddAsync(technology);
            return RedirectToAction(nameof(Index));
        }

        // Display Edit form
        public async Task<IActionResult> Edit(int id)
        {
            var technology = await _technologyRepository.GetByIdAsync(id);
            if (technology == null)
            {
                return NotFound();
            }
            return View(technology);
        }

        // Handle Edit form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Technology technology)
        {
            if (id != technology.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(technology);
            }

            await _technologyRepository.UpdateAsync(technology);
            return RedirectToAction(nameof(Index));
        }

        // Display Delete confirmation page
        public async Task<IActionResult> Delete(int id)
        {
            var technology = await _technologyRepository.GetByIdAsync(id);
            if (technology == null)
            {
                return NotFound();
            }
            return View(technology);
        }

        // Handle Delete confirmation
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _technologyRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
