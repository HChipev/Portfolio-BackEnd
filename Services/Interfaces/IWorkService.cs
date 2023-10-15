using Common;
using Data.ViewModels.Work.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface IWorkService : IService
    {
        public ServiceResult<bool> AddWork(WorkViewModel work);

        public ServiceResult<bool> DeleteWork(int id);

        public ServiceResult<bool> UpdateWork(WorkViewModel work);

        public ServiceResult<WorkViewModel> GetWork(int id);

        public ServiceResult<IEnumerable<WorkViewModel>> GetWorks();
    }
}