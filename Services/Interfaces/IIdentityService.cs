using Common;
using Data.ViewModels.Identity.Models;
using Data.ViewModels.Token.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface IIdentityService : IService
    {
        public Task<ServiceResult<TokensResponseViewModel>> LoginAsync(UserLoginViewModel user);

        public Task<ServiceResult<bool>> LogoutAsync();

        public ServiceResult<TokensResponseViewModel> RefreshTokenAsync(TokenViewModel tokens);
    }
}