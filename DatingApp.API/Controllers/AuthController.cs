using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Dtos;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        public AuthController(IAuthRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto user)
        {
            // todo: validate request

            user.Username = user.Username.ToLower();

            if (await _repository.UserExists(user.Username))
            {
                return BadRequest("Username already exists");
            }

            var userToRegister = new User
            {
                Username = user.Username,
            };

            var newUser = await _repository.Register(userToRegister, user.Password);

            // created at route
            return StatusCode(201);
        }

        /* [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto user)
        {
            
        } */
    }


}