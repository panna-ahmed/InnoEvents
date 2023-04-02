using Microsoft.EntityFrameworkCore;

namespace InnoEvents.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }

    }
}
