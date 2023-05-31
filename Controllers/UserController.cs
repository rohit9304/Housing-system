using Housing_system.BussinessLayer.DTO;
using Housing_system.BussinessLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace Housing_system.Controllers
{

    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserRegistrationDto userDto)
        {
            try
            {
                _userService.RegisterUser(userDto);
                return Ok("User registered successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            try
            {
                var token = _userService.AuthenticateUser(userLoginDto);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
