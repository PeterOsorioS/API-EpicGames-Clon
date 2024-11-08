
namespace Epic.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IGameRepository Game { get; }

        void Save();
        Task SaveAsync();
    }
}
