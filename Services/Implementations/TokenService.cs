using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Token.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Services.Interfaces;

namespace Services.Implementations
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _repository;

        public TokenService(IRepository<User> repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }

        public TokenViewModel GenerateAccessToken(string email, int id, bool isLogin = false)
        {
            int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out var tokenValidityInMinutes);
            var expiration = DateTime.UtcNow.AddMinutes(tokenValidityInMinutes);

            var accessToken = CreateJwtToken(
                CreateClaims(email, id),
                CreateSigningCredentials(),
                expiration
            );

            int.TryParse(_configuration["JWT:RefreshTokenValidityInDays"], out var refreshTokenValidityInDays);
            var refreshTokenExpiration = DateTime.UtcNow.AddDays(refreshTokenValidityInDays);

            var refreshToken = CreateRefreshTokenJwt(
                CreateSigningCredentials(),
                refreshTokenExpiration
            );

            var accessTokenString = new JwtSecurityTokenHandler().WriteToken(accessToken);
            var refreshTokenString = new JwtSecurityTokenHandler().WriteToken(refreshToken);

            var dbUser = _repository.Find(id);

            if (dbUser.RefreshTokenExpiryTime < DateTime.UtcNow || dbUser.RefreshToken is null || isLogin)
            {
                dbUser.RefreshToken = refreshTokenString;
                dbUser.RefreshTokenExpiryTime = refreshTokenExpiration;
            }

            _repository.Update(dbUser);
            _repository.SaveChanges();

            return new TokenViewModel
            {
                Token = accessTokenString,
                RefreshToken = refreshTokenString
            };
        }

        private JwtSecurityToken CreateJwtToken(Claim[] claims, SigningCredentials credentials, DateTime expiration)
        {
            return new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }

        private JwtSecurityToken CreateRefreshTokenJwt(SigningCredentials credentials, DateTime expiration)
        {
            return new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                expires: expiration,
                signingCredentials: credentials
            );
        }

        private Claim[] CreateClaims(string email, int id)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Email, email),
                new(ClaimTypes.NameIdentifier, id.ToString())
            };

            return claims.ToArray();
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"])
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}