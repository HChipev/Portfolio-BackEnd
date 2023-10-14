using AutoMapper;
using Data.ViewModels.Language.Models;

namespace Data.ViewModels.Language.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Entities.Language, LanguageViewModel>().ReverseMap();
        }
    }
}