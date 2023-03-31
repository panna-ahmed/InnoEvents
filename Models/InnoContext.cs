using Microsoft.EntityFrameworkCore;

namespace InnoEvents.Models
{
    public class InnoContext : DbContext
    {
        public InnoContext(DbContextOptions<InnoContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserEvent> UserEvents { get; set; }

    }
}
