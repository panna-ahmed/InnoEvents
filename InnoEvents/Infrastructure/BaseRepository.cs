using InnoEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace InnoEvents.Infrastructure
{
    public class BaseRepository
    {
        protected readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            if (!ChangeTracker())
                return true;

            return await _context.SaveChangesAsync() > 0;
        }

        public bool ChangeTracker()
        {
            bool isChanged = false;
            var entries = _context.ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.State != EntityState.Unchanged)
                {
                    isChanged = true;
                }
            }

            return isChanged;
        }
    }
}
