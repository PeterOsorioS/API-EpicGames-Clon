using Epic.Domain.Interface;
using Epic.Infrastructure.Persistence;
using Epic.Infrastructure.Repositories;


namespace Epic.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            User = new UserRepository(_db);
            Game = new GameRepository(_db);
        }

        public IUserRepository User { get; private set; }
        public IGameRepository Game { get; private set; }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
