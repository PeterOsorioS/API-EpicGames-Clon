using Epic.Domain.Entities;
using Epic.Domain.Interface;
using Epic.Infrastructure.Migrations;
using Epic.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Epic.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }
        public void Add(User user)
        {
            _db.users.Add(user);
        }

        public async Task AddAsync(User user)
        {
           await _db.AddAsync(user);
        }

        public User GetByEmail(string Email)
        {
            var user = _db.users.FirstOrDefault(u => u.Email == Email);
            return user;
        }

        public async Task<User> GetByEmailAsync(string Email)
        {
            var user = await _db.users.FirstOrDefaultAsync(u => u.Email == Email);
            return user;
        }
        public User GetByUsername(string Username)
        {
            var user = _db.users.FirstOrDefault(u => u.UserName == Username);
            return user;
        }
        public async Task<User> GetByUsernameAsync(string Username)
        {
            var user = await _db.users.FirstOrDefaultAsync(u => u.UserName == Username);
            return user;
        }
    }
}
