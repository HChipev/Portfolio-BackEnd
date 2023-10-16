using Common;
using Data.ViewModels.Certificate.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface ICertificateService : IService
    {
        public ServiceResult<bool> AddCertificate(CertificateViewModel certificate);

        public ServiceResult<bool> DeleteCertificate(int id);

        public ServiceResult<bool> UpdateCertificate(CertificateViewModel certificate);

        public ServiceResult<CertificateViewModel> GetCertificate(int id);

        public ServiceResult<IEnumerable<CertificateViewModel>> GetCertificates();
    }
}