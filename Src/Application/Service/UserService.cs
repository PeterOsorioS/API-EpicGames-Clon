using Epic.Application.DTOs;
using Epic.Application.IUnitOfWork;
using Epic.Application.Service.IService;


namespace Epic.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(RegisterDTO register)
        {

        }

    }
}
