using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using moneygoes.Models;
using moneygoes.Models.DTOs;
using moneygoes.Models.ViewModels.Account;
using moneygoes.Services;

namespace moneygoes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IMapper mapper,
            ILoggerFactory loggerFactory
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<AccountController>();
        }

        [HttpGet("[action]")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("qweqwe");
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorDto { Data = string.Join(", ", ModelState.Values), ErrorCode = 400 });
            }
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation(1, "User logged in.");
                    return Ok(_mapper.Map<AppUserDto>(await _userManager.FindByEmailAsync(model.Email)));
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
            var user = _mapper.Map<AppUser>(model);
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    _logger.LogInformation(3, "User created a new account with password.");
                    return Ok(_mapper.Map<AppUserDto>(await _userManager.FindByEmailAsync(model.Email)));
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