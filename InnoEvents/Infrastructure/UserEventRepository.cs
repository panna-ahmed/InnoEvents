using InnoEvents.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InnoEvents.Infrastructure
{
    public class UserEventRepository: BaseRepository, IUserEventRepository
    {
        public UserEventRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<UserEvent>> GetAllAsync(Expression<Func<UserEvent, bool>> predicate, int pageNumber, int pageSize)
        {
            return await _context.Set<UserEvent>().Where(predicate)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<UserEvent> SingleOrDefaultAsync(Expression<Func<UserEvent, bool>> predicate)
        {
            return await _context.Set<UserEvent>().Where(predicate).SingleOrDefaultAsync();
        }

        public async Task AddAsync(UserEvent ev)
        {
            await _context.Set<UserEvent>().AddAsync(ev);
        }

        public void Remove(UserEvent ev)
        {
            _context.Set<UserEvent>().Remove(ev);
        }

        public async Task<bool> ExistsAsync(int eventId, int userId)
        {
            return await _context.Set<UserEvent>().AnyAsync(e => e.EventId == eventId && e.UserId == userId);
        }
    }
}
