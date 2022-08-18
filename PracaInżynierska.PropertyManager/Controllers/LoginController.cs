using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PracaInżynierska.Domain.Models;

namespace PracaInżynierska.PropertyManager.Controllers
{
    [ApiController]
    [Route("api")]
    public class LoginController : Controller
    {
        
        [HttpGet("register")]
        public IActionResult Register()
        {

            return Ok();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {

            return Ok();
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {

            return Ok();
        }
    }
}
