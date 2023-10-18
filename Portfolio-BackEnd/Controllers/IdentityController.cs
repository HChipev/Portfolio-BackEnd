using Data.ViewModels.Identity.Models;
using Data.ViewModels.Token.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Portfolio_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService, IConfiguration configuration)
        {
            _identityService = identityService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel userModel)
        {
            var result = await _identityService.LoginAsync(userModel);
            if (result.IsSuccess)
            {
                Response.Headers.Add("Access-Token", result.Data.Tokens.Token);
                Response.Headers.Add("Refresh-Token", result.Data.Tokens.RefreshToken);

                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            var result = await _identityService.LogoutAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public IActionResult RefreshToken([FromBody] TokenViewModel tokensModel)
        {
            var result = _identityService.RefreshTokenAsync(tokensModel);
            if (result.IsSuccess)
            {
                int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out var refreshTokenValidityInDays);
                int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out var tokenValidityInMinutes);

                Response.Headers.Add("Access-Token", result.Data.Tokens.Token);

                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}