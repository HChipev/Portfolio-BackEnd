using AutoMapper;
using Common;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Certificate.Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CertificateService : ICertificateService
    {
        private readonly IRepository<Certificate> _certificateRepository;
        private readonly IMapper _mapper;

        public CertificateService(IRepository<Certificate> certificateRepository, IMapper mapper)
        {
            _certificateRepository = certificateRepository;
            _mapper = mapper;
        }

        public ServiceResult<bool> AddCertificate(CertificateViewModel certificate)
        {
            try
            {
                _certificateRepository.Add(_mapper.Map<Certificate>(certificate));
                _certificateRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<bool> DeleteCertificate(int id)
        {
            try
            {
                _certificateRepository.Remove(id);
                _certificateRepository.SaveChanges();

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

        public ServiceResult<bool> UpdateCertificate(CertificateViewModel certificate)
        {
            try
            {
                _certificateRepository.Update(_mapper.Map<Certificate>(certificate));
                _certificateRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<CertificateViewModel> GetCertificate(int id)
        {
            try
            {
                var certificate = _certificateRepository.Find(id);

                return new ServiceResult<CertificateViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<CertificateViewModel>(certificate)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<CertificateViewModel> { Message = e.Message, IsSuccess = false };
            }
        }

        public ServiceResult<IEnumerable<CertificateViewModel>> GetCertificates()
        {
            try
            {
                var certificates = _certificateRepository.GetAll();

                return new ServiceResult<IEnumerable<CertificateViewModel>>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<CertificateViewModel>>(certificates)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<CertificateViewModel>> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}