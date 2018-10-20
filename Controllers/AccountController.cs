using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moneygoes.Models;
using moneygoes.Models.DTOs;
using moneygoes.Models.ViewModels.Account;

namespace moneygoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILoggerFactory loggerFactory
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpGet("[action]")]
        public IActionResult Test() => Ok();

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorDto { Data = string.Join(", ", ModelState.Values), ErrorCode = 400 });
            }
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return Ok('/');
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Login failed");
            }

            return StatusCode(401, new ErrorDto { Data = "Could not log in", ErrorCode = 400 });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorDto { Data = string.Join(", ", ModelState.Values), ErrorCode = 400 });
            }
            var user = new AppUser { UserName = model.Email, Email = model.Email };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    return Ok('/');
                }
                return StatusCode(401, new ErrorDto { Data = string.Join(", ", result.Errors.Select(error => error.Description)), ErrorCode = 401 });
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Registration failed");
            }
            return StatusCode(401, new ErrorDto { Data = "Could not register", ErrorCode = 401 });
        }

    }
}