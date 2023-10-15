using AutoMapper;
using Data.ViewModels.Education.Models;

namespace Data.ViewModels.Education.Profiles
{
    public class EducationProfile : Profile
    {
        public EducationProfile()
        {
            CreateMap<Entities.Education, EducationViewModel>().ReverseMap();
        }
    }
}