using AutoMapper;
using Data.ViewModels.Certificate.Models;

namespace Data.ViewModels.Certificate.Profiles
{
    public class CertificateProfile : Profile
    {
        public CertificateProfile()
        {
            CreateMap<Entities.Certificate, CertificateViewModel>().ReverseMap();
        }
    }
}