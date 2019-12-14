using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NUShop.Data.Entities;
using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels.AccountViewModels;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using NUShop.WebAPI.Helpers;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountEFController : ControllerBase
    {
        #region Injections

        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountEFController> _logger;
        private readonly IConfiguration _config;

        public AccountEFController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<AccountEFController> logger, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _config = config;
        }

        #endregion Injections

        #region API

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticationAsync(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return new OkObjectResult(new GenericResult(false, loginViewModel));
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, true);
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(result.ToString());
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return new OkObjectResult(new GenericResult(false, "User account locked out."));
            }

            var user = await _userManager.FindByNameAsync(loginViewModel.Username);
            if (user != null)
            {
                //var roles = await _userManager.GetRolesAsync(user);
                //var token = JwtToken.GenerateJwtToken(user, roles, _config);
                //var tokenHandler = new JwtSecurityTokenHandler();
                _logger.LogInformation("User logged in.");
                return new OkObjectResult(user);
            }
            _logger.LogWarning("User account locked out.");
            return new OkObjectResult(new GenericResult(false, "User account locked out."));
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }

        #endregion API
    }
}