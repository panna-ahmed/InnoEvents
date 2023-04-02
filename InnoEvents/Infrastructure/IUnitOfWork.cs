namespace InnoEvents.Infrastructure
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IEventRepository EventRepository { get; }
        IUserEventRepository EventUserRepository { get; }
    }
}
