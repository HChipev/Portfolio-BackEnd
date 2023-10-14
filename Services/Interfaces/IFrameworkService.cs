using Common;
using Data.ViewModels.Framework.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface IFrameworkService : IService
    {
        public ServiceResult<bool> AddFramework(FrameworkViewModel language);

        public ServiceResult<bool> DeleteFramework(int id);

        public ServiceResult<bool> UpdateFramework(FrameworkViewModel language);

        public ServiceResult<FrameworkViewModel> GetFramework(int id);

        public ServiceResult<IEnumerable<FrameworkViewModel>> GetFrameworks();
    }
}