using InnoEvents.Models;

namespace InnoEvents.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly string _restApiUrl;

        private IUserRepository _userRepository;
        private IEventRepository _eventRepository;
        private IUserEventRepository _eventUserRepository;

        public UnitOfWork(ApplicationDbContext context, string restApiUrl = "https://jsonplaceholder.typicode.com/")
        {
            _context = context;
            _restApiUrl = restApiUrl;
        }

        public IUserRepository UserRepository => _userRepository ??= new UserRepository(_restApiUrl);
        public IEventRepository EventRepository => _eventRepository ??= new EventRepository(_context);
        public IUserEventRepository EventUserRepository => _eventUserRepository ??= new UserEventRepository(_context);

        public void Dispose() => _context.Dispose();

    }
}
