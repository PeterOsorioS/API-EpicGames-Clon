using Epic.Domain.Entities;

namespace Epic.Application.Interface
{
    public interface IJwtUtility
    {
        public string CreateToken(User user);
    }
}
