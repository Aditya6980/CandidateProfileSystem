using CandidateProfileSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidateProfileSystem.Repositories
{
    public interface ICandidateRepository
    {
        Task<IEnumerable<Candidate>> GetAllAsync();
        Task<Candidate?> GetByIdAsync(int id);
        Task AddAsync(Candidate candidate);
        Task UpdateAsync(Candidate candidate);
        Task DeleteAsync(int id); // Ensure return type is just Task
    }
}
