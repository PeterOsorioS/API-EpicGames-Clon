using Epic.Domain.Entities;
using Epic.Domain.Interface;
using Epic.Domain.ValueObjects;
using Epic.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Epic.Infrastructure.Repositories
{
    public class GameRepository : Repository<Game>, IGameRepository
    {
        private readonly ApplicationDbContext _db;
        public GameRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public IEnumerable<Game> GetGamesByGenre(Genre genre)
        {
            var games = _db.games.Where(g => g.Genre == genre);
            return games.ToList();
        }
        public async Task<IEnumerable<Game>> GetGamesByGenreAsync(Genre genre)
        {
            var games = _db.games.Where(g => g.Genre == genre);
            return await games.ToListAsync();
        }
    }
}
