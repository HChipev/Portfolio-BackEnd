using AutoMapper;
using Data.ViewModels.Tool.Models;

namespace Data.ViewModels.Tool.Profiles
{
    public class ToolProfile : Profile
    {
        public ToolProfile()
        {
            CreateMap<Entities.Tool, ToolViewModel>().ReverseMap();
        }
    }
}