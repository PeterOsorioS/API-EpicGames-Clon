using Epic.Application.DTOs;
using Epic.Application.Interface;
using Epic.Application.Service;
using Epic.Domain.Interface;
using Epic.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Epic.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login([FromBody]LoginDTO login)
        {
            _userService.Authentication(login);
            return Ok();
        }

        [HttpPost("regiser")]
        public IActionResult Register([FromBody] RegisterDTO register)
        {
            _userService.Create(register);
            return Ok();
        }
    }
}
