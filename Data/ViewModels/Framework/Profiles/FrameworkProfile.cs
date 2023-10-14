using AutoMapper;
using Data.ViewModels.Framework.Models;

namespace Data.ViewModels.Framework.Profiles
{
    public class FrameworkProfile : Profile
    {
        public FrameworkProfile()
        {
            CreateMap<Entities.Framework, FrameworkViewModel>().ReverseMap();
        }
    }
}