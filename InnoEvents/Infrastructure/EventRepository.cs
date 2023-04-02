using InnoEvents.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace InnoEvents.Infrastructure
{
    public class EventRepository: BaseRepository, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Event>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Set<Event>().OrderBy(on => on.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync(Expression<Func<Event, bool>> predicate, int pageNumber, int pageSize)
        {
            return await _context.Set<Event>().Where(predicate).Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Event> SingleOrDefaultAsync(Expression<Func<Event, bool>> predicate)
        {
            return await _context.Set<Event>().Where(predicate).SingleOrDefaultAsync();
        }

        public async Task AddAsync(Event ev)
        {
            await _context.Set<Event>().AddAsync(ev);
        }

        public void Remove(Event ev)
        {
            _context.Set<Event>().Remove(ev);
        }

        public bool Exists(int id)
        {
            return _context.Set<Event>().Any(e => e.Id == id);
        }
    }
}
