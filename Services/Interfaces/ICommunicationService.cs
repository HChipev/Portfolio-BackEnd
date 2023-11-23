using Common;
using Data.ViewModels.Communication.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface ICommunicationService : IService
    {
        public Task<ServiceResult<bool>> SendEmail(CommunicationViewModel communication);
    }
}