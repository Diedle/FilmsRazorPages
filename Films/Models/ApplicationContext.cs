using Microsoft.EntityFrameworkCore;

namespace Films.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Film> Films { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();  
        }
    }
}
