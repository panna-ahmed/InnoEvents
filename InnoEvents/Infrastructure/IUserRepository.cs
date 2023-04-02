using InnoEvents.DTOs;

namespace InnoEvents.Infrastructure
{
    public interface IUserRepository
    {
        Task<User> Get(int id);
    }
}
