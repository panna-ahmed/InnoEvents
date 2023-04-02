using InnoEvents.Models;
using System.Linq.Expressions;

namespace InnoEvents.Infrastructure
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Event>> GetAllAsync(Expression<Func<Event, bool>> predicate, int pageNumber, int pageSize);
        Task<Event> SingleOrDefaultAsync(Expression<Func<Event, bool>> predicate);
        Task AddAsync(Event entity);
        void Remove(Event entity);
        bool Exists(int id);

        Task<bool> SaveChangesAsync();
    }
}
