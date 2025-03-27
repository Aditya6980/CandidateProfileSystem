using CandidateProfileSystem.Data;
using CandidateProfileSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateProfileSystem.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly ApplicationDbContext _context;

        public TechnologyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all technologies
        public async Task<IEnumerable<Technology>> GetAllAsync()
        {
            return await _context.Technologies.ToListAsync();
        }

        // Get a technology by ID
        public async Task<Technology?> GetByIdAsync(int id)
        {
            return await _context.Technologies.FindAsync(id);
        }

        // Add a new technology
        public async Task AddAsync(Technology technology)
        {
            await _context.Technologies.AddAsync(technology);
            await _context.SaveChangesAsync();
        }

        // Update an existing technology
        public async Task UpdateAsync(Technology technology)
        {
            _context.Entry(technology).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Fix: Delete a technology by ID
        public async Task DeleteAsync(int id)
        {
            var technology = await _context.Technologies.FindAsync(id);
            if (technology != null)
            {
                _context.Technologies.Remove(technology);
                await _context.SaveChangesAsync();
            }
        }
    }
}
