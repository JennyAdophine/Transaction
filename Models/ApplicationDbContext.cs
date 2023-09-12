using Microsoft.EntityFrameworkCore;

namespace AssessmentTransaction.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties go here for your database entities
        public DbSet<Users> Users { get; set; } = null!;
    }
}

