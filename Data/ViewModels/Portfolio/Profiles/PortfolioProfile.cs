using AutoMapper;
using Data.ViewModels.Portfolio.Models;

namespace Data.ViewModels.Portfolio.Profiles
{
    public class PortfolioProfile : Profile
    {
        public PortfolioProfile()
        {
            CreateMap<Entities.Portfolio, PortfolioViewModel>().ReverseMap();
        }
    }
}