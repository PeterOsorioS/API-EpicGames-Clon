using Epic.Domain.Entities;
using Epic.Domain.ValueObjects;


namespace Epic.Domain.Interface
{
    public interface IGameRepository: IRepository<Game>
    {
        IEnumerable<Game> GetGamesByGenre(Genre genre);
        Task<IEnumerable<Game>> GetGamesByGenreAsync(Genre genre);
    }
}
