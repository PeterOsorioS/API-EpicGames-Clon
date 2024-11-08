using System.Linq.Expressions;


namespace Epic.Domain.Interface
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        Task<T> GetByIdAsync(int id);

        IEnumerable<T> GetAll(
          Expression<Func<T, bool>>? filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
          string? includeProperties = null
        );

        Task<IEnumerable<T>> GetAllAsync(
          Expression<Func<T, bool>>? filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
          string? includeProperties = null
        );

        int GetAllCount(Expression<Func<T, bool>>? filter = null);

        Task<int> GetAllCountAsync(Expression<Func<T, bool>>? filter = null);

        T GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
        );

        Task<T> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
        );

    }
}
