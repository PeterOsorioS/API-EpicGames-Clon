using Epic.Application.DTOs;
using Epic.Application.Exceptions;
using Epic.Application.Interface;
using Epic.Domain.Entities;
using Epic.Domain.Interface;
using Mapster;
using Microsoft.AspNetCore.Identity;



namespace Epic.Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<User> _password;
        private readonly IJwtUtility _jwtUtility;
        public UserService(IUnitOfWork unitOfWork,
            IPasswordHasher<User> password,
            IJwtUtility jwtUtility)
        {
            _unitOfWork = unitOfWork;
            _password = password;
            _jwtUtility = jwtUtility;
        }

        public string Create(RegisterDTO register)
        {
            // Entity validation
            var exisingUser = _unitOfWork.User.GetFirstOrDefault(
                u => u.Email == register.Email || u.UserName == register.UserName);


            // Error handling
            if (exisingUser != null)
            {
                if (exisingUser.Email == register.Email)
                {
                    throw new BadRequestException("User with this email already exists.");
                }

                if (exisingUser.UserName == register.UserName)
                {
                    throw new BadRequestException("User with this username already exists.");
                }
            }

            // Entity mapping
            var user = register.Adapt<User>();

            // User creation
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();

            // Token creation
            var token = _jwtUtility.CreateToken(user);
            return token;
        }

        public void Authentication(LoginDTO login)
        {
            try
            {
                var UserDb = _unitOfWork.User.GetByEmail(login.Email);

                var passwordHash = _password.VerifyHashedPassword(
                  UserDb, UserDb.Password, login.Password);

                if (UserDb == null)
                {
                    throw new UnauthorizedAccessException("User credentials error.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
