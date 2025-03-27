using CandidateProfileSystem.Models;
using CandidateProfileSystem.Repositories;
using CandidateProfileSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateProfileSystem.Controllers
{
    public class CandidateController : Controller
    {
        //DI
        private readonly ApplicationDbContext _context;
        private readonly ICandidateRepository _candidateRepository;

        //Ctor
        public CandidateController(ApplicationDbContext context, ICandidateRepository candidateRepository)
        {
            _context = context;
            _candidateRepository = candidateRepository;
        }

        // Display all candidates
        public async Task<IActionResult> Index()
        {
            var candidates = await _candidateRepository.GetAllAsync();
            return View(candidates);
        }

        // Display Create form
        public async Task<IActionResult> Create()
        {
            ViewBag.Technologies = await _context.Technologies.ToListAsync();
            return View(new Candidate());
        }

        // Handle Create form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Candidate candidate)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Technologies = await _context.Technologies.ToListAsync();
                return View(candidate);
            }

            await _candidateRepository.AddAsync(candidate);
            return RedirectToAction(nameof(Index));
        }

        // Display Edit form
        public async Task<IActionResult> Edit(int id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            ViewBag.Technologies = await _context.Technologies.ToListAsync();
            return View(candidate);
        }

        // Handle Edit form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Technologies = await _context.Technologies.ToListAsync();
                return View(candidate);
            }

            await _candidateRepository.UpdateAsync(candidate);
            return RedirectToAction(nameof(Index));
        }

        // Handle Delete via AJAX
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _candidateRepository.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            await _candidateRepository.DeleteAsync(id);
            return Json(new { success = true }); // Return JSON response for AJAX
        }

    }
}
