using Epic.Application.DTOs;
using Epic.Domain.Entities;

namespace Epic.Application.Interface
{
    public interface IUserService
    {
       string Create(RegisterDTO register);
       void Authentication(LoginDTO login);
    }
}
