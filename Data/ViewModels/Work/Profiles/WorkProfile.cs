using AutoMapper;
using Data.ViewModels.Work.Models;

namespace Data.ViewModels.Work.Profiles
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Entities.Work, WorkViewModel>().ReverseMap();
        }
    }
}