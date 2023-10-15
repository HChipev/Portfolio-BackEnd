using AutoMapper;
using Data.ViewModels.Position.Models;

namespace Data.ViewModels.Position.Profiles
{
    public class PositionProfile : Profile
    {
        public PositionProfile()
        {
            CreateMap<Entities.Position, PositionViewModel>().ReverseMap();
        }
    }
}