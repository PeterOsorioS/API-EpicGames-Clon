using Epic.Application.DTOs;

namespace Epic.Application.Service.IService
{
    public interface IUserService
    {
        void Create(RegisterDTO register);
    }
}
