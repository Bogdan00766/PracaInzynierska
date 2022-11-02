using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PracaInżynierska.Application.Dto;
using PracaInżynierska.Application.Interfaces;
using PracaInżynierska.Domain.Models;

namespace PracaInżynierska.PropertyManager.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<User> _logger;

        public LoginController(IUserService userService, ILogger<User> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("Register")]
        public IActionResult Register(RegisterUserDto rud)
        {
            _logger.LogInformation("Register POST request");
            UserDto newUser;
            try
            {
                newUser = _userService.Register(rud.Name, rud.Password, rud.EMail);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest(e.Message);
            }
            _logger.LogCritical($"User {newUser.Name} created");
            return Created("/api/users/login", newUser);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserDto lud)
        {

            UserDto user;
            try
            {
                user = _userService.Login(lud.EMail, lud.Password);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("Wrong password")) return BadRequest("Wrong password");
                if (e.Message.Contains("User not found")) return BadRequest("User not found");
                return StatusCode(500);
            }

            var resp = new HttpResponseMessage();

            Guid guid = Guid.NewGuid();
            _userService.SetGuid(guid, user.Id);
            HttpContext.Response.Cookies.Append("GUID", guid.ToString(), new Microsoft.AspNetCore.Http.CookieOptions
            {
                Expires = DateTime.Now.AddSeconds(10),
            });

            return Ok(user);
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            var guidString = Request.Cookies["GUID"];
            Guid guid;
            if(guidString == null)
            {
                return Unauthorized();
            }
            try
            {
                guid = Guid.Parse(guidString);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Error while parsing guid: {guidString}");
                return BadRequest("Error while parsing guid");
            }
            try
            {
                _logger.LogDebug($"Wylogowano {guidString}");
                _userService.Logout(guid);
                return Ok();
            }
            catch (Exception e)
            {
                return Unauthorized(e.Message);
            }
        }

        [HttpGet("isLogged")]
        public IActionResult IsLogged()
        {
            var guidString = Request.Cookies["GUID"];
            Guid guid;
            try
            {
                guid = Guid.Parse(guidString);
            }
            catch (Exception e)
            {
                _logger.LogCritical($"Error while parsing guid: {guidString}");
                return BadRequest("Error while parsing guid");
            }
            if (_userService.IsLogged(guid)) return Ok(true);
            return Unauthorized(false);
        }

        [HttpDelete]
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();

            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);

            Response.Cookies.Append(key, value, option);
        }
    }
}
