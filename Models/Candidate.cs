using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidateProfileSystem.Models
{
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string ContactNumber { get; set; }

        [Required]
        public string DegreeName { get; set; }

        [Required]
        public int DegreeCompletionYear { get; set; }

        [ForeignKey("Technology")]
        public int? TechnologyId { get; set; }

        //navigation prop
        public Technology? Technology { get; set; } 
    }
}
