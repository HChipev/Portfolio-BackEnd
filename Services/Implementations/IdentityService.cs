using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Identity.Models;
using Data.ViewModels.Token.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace Services.Implementations
{
    public class IdentityService : IIdentityService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _repository;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        public IdentityService(IRepository<User> repository, UserManager<User> userManager,
            SignInManager<User> signInManager,
            ITokenService tokenService, IConfiguration configuration)
        {
            _repository = repository;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        public async Task<ServiceResult<TokensResponseViewModel>> LoginAsync(UserLoginViewModel user)
        {
            var messages = "";

            try
            {
                var dbUser = await _userManager.FindByEmailAsync(user.Email);

                if (dbUser == null)
                {
                    return new ServiceResult<TokensResponseViewModel>
                        { IsSuccess = false, Message = "Invalid email or password", Data = null };
                }

                if (dbUser.EmailConfirmed)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

                    if (result.Succeeded)
                    {
                        var id = dbUser.Id;

                        return new ServiceResult<TokensResponseViewModel>
                        {
                            IsSuccess = true, Message = "",
                            Data = new TokensResponseViewModel
                                { Tokens = _tokenService.GenerateAccessToken(user.Email, id, true) }
                        };
                    }

                    return new ServiceResult<TokensResponseViewModel>
                        { IsSuccess = false, Message = "Invalid email or password", Data = null };
                }

                return new ServiceResult<TokensResponseViewModel>
                {
                    IsSuccess = false, Message = "Email is not confirmed. Please confirm your email.", Data = null
                };
            }
            catch (Exception ex)
            {
                messages += $"{ex.Message}";
                return new ServiceResult<TokensResponseViewModel>
                    { IsSuccess = false, Message = messages, Data = null };
            }
        }


        public ServiceResult<TokensResponseViewModel> RefreshTokenAsync(TokenViewModel tokens)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken;

                var principal = tokenHandler.ValidateToken(tokens.Token, new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey
                        (Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Audience"],
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true
                }, out securityToken);
                var validatedToken = securityToken as JwtSecurityToken;

                if (validatedToken?.Header.Alg != SecurityAlgorithms.HmacSha256)
                {
                    return new ServiceResult<TokensResponseViewModel>
                        { IsSuccess = false, Message = "Invalid algorithm", Data = null };
                }

                var nameIdentifier = int.Parse(principal.FindFirst(ClaimTypes.NameIdentifier).Value);

                var user = _repository.FindByCondition(u =>
                    u.Id == nameIdentifier && u.RefreshToken == Uri.UnescapeDataString(tokens.RefreshToken));

                if (user is null || user?.RefreshTokenExpiryTime < DateTime.UtcNow)
                {
                    return new ServiceResult<TokensResponseViewModel>
                        { IsSuccess = false, Message = "Invalid token", Data = null };
                }

                var newTokens = _tokenService.GenerateAccessToken(user.Email, user.Id);
                return new ServiceResult<TokensResponseViewModel>
                    { IsSuccess = true, Message = "", Data = new TokensResponseViewModel { Tokens = newTokens } };
            }
            catch (Exception ex)
            {
                return new ServiceResult<TokensResponseViewModel>
                    { IsSuccess = false, Message = ex.Message, Data = null };
            }
        }
    }
}