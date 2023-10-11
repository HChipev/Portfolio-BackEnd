using Data.ViewModels.Token.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface ITokenService : IService
    {
        public TokenViewModel GenerateAccessToken(string email, int id,
            bool isLogin = false);
    }
}