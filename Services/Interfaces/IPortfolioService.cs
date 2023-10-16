using Common;
using Data.ViewModels.Portfolio.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface IPortfolioService : IService
    {
        public ServiceResult<bool> AddPortfolio(PortfolioViewModel portfolio);

        public ServiceResult<bool> DeletePortfolio(int id);

        public ServiceResult<bool> UpdatePortfolio(PortfolioViewModel portfolio);

        public ServiceResult<PortfolioViewModel> GetPortfolio(int id);

        public ServiceResult<IEnumerable<PortfolioViewModel>> GetPortfolios();
    }
}