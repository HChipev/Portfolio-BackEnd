using AutoMapper;
using Common;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Portfolio.Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class PortfolioService : IPortfolioService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Portfolio> _portfolioRepository;

        public PortfolioService(IRepository<Portfolio> portfolioRepository, IMapper mapper)
        {
            _portfolioRepository = portfolioRepository;
            _mapper = mapper;
        }

        public ServiceResult<bool> AddPortfolio(PortfolioViewModel portfolio)
        {
            try
            {
                _portfolioRepository.Add(_mapper.Map<Portfolio>(portfolio));
                _portfolioRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<bool> DeletePortfolio(int id)
        {
            try
            {
                _portfolioRepository.Remove(id);
                _portfolioRepository.SaveChanges();

                return new ServiceResult<bool>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = true
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<bool> UpdatePortfolio(PortfolioViewModel portfolio)
        {
            try
            {
                _portfolioRepository.Update(_mapper.Map<Portfolio>(portfolio));
                _portfolioRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<PortfolioViewModel> GetPortfolio(int id)
        {
            try
            {
                var portfolio = _portfolioRepository.Find(id);

                return new ServiceResult<PortfolioViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<PortfolioViewModel>(portfolio)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<PortfolioViewModel> { Message = e.Message, IsSuccess = false };
            }
        }

        public ServiceResult<IEnumerable<PortfolioViewModel>> GetPortfolios()
        {
            try
            {
                var portfolios = _portfolioRepository.GetAll();

                return new ServiceResult<IEnumerable<PortfolioViewModel>>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<PortfolioViewModel>>(portfolios)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<PortfolioViewModel>> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}