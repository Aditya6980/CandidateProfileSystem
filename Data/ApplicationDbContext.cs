using CandidateProfileSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CandidateProfileSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets representing tables
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Technology> Technologies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define cascading delete for Technology-Candidate relation
            modelBuilder.Entity<Candidate>()
                .HasOne(c => c.Technology)
                .WithMany()
                .HasForeignKey(c => c.TechnologyId)
                .OnDelete(DeleteBehavior.Cascade); // This enables cascading delete

            // Seed Technologies
            modelBuilder.Entity<Technology>().HasData(
                new Technology { Id = 1, TechnologyName = "Java" },
                new Technology { Id = 2, TechnologyName = "C#" }
            );
            // Seed Candidates
            modelBuilder.Entity<Candidate>().HasData(
                new Candidate
                {
                    Id = 1,
                    Name = "Rahul",
                    Email = "rahulg@gmail.com",
                    ContactNumber = "9878",
                    DegreeName = "BTech",
                    DegreeCompletionYear = 2025,
                    TechnologyId = 1  // Java
                },
                new Candidate
                {
                    Id = 2,
                    Name = "Sky",
                    Email = "sky@gmail.com",
                    ContactNumber = "9879",
                    DegreeName = "BTech",
                    DegreeCompletionYear = 2025,
                    TechnologyId = 2  // C#
                }
            );
        }
    }
}
