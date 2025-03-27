using CandidateProfileSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateProfileSystem.Repositories
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<Technology>> GetAllAsync();
        Task<Technology?> GetByIdAsync(int id);
        Task AddAsync(Technology technology);
        Task UpdateAsync(Technology technology);
        Task DeleteAsync(int id);
    }
}
