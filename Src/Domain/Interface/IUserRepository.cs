using Epic.Domain.Entities;

namespace Epic.Domain.Interface
{
    public interface IUserRepository: IRepository<User>
    {
        void Add(User user);
        Task AddAsync(User user);
        User GetByEmail(string Email);
        Task<User> GetByEmailAsync(string Email);
        User GetByUsername(string Username);
        Task<User> GetByUsernameAsync(string Username);
    }
}
