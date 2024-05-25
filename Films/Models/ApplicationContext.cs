using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FilmsCore.Models;

namespace Films.Models
{
    public sealed class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Film> Films { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;
    }
}
