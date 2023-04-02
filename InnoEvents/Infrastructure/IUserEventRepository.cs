using InnoEvents.Models;
using System.Linq.Expressions;

namespace InnoEvents.Infrastructure
{
    public interface IUserEventRepository
    {
        Task<IEnumerable<UserEvent>> GetAllAsync(Expression<Func<UserEvent, bool>> predicate, int pageNumber, int pageSize);
        Task<UserEvent> SingleOrDefaultAsync(Expression<Func<UserEvent, bool>> predicate);
        Task AddAsync(UserEvent entity);
        void Remove(UserEvent entity);
        Task<bool> ExistsAsync(int eventId, int userId);

        Task<bool> SaveChangesAsync();
    }
}
