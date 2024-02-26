using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Family> Families { get; set; }
        public DbSet<Person> People { get; set; }
    }
}
