
using Microsoft.EntityFrameworkCore;

namespace AssessmentTransaction.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            Users = Set<Users>(); // Initialize the Users DbSet
        }

        public DbSet<Users> Users { get; set; }
    }
}
