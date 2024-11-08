using Epic.Domain.IRepositories;

namespace Epic.Application.IUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IGameRepository Game { get; }

        void Save();
        Task SaveAsync();
    }
}
