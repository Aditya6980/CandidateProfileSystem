using System.ComponentModel.DataAnnotations;

namespace CandidateProfileSystem.Models
{
    public class Technology
    {
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string TechnologyName { get; set; } = string.Empty; // Required & Unique
    }
}
