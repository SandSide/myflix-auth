using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Myflix.AuthService.Models;

namespace Myflix.AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                return Ok("Signed In");
            }

            return Unauthorized();
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Username };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return Ok(new { Message = "User registered successfully" });
                }
 
                return BadRequest(new { Message = "Registration failed", Errors = result.Errors });

            }

            return BadRequest(new { Message = "Invalid registration data" });
        }
    }
}
