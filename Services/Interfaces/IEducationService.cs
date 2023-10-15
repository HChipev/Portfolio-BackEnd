using Common;
using Data.ViewModels.Education.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface IEducationService : IService
    {
        public ServiceResult<bool> AddEducation(EducationViewModel education);

        public ServiceResult<bool> DeleteEducation(int id);

        public ServiceResult<bool> UpdateEducation(EducationViewModel education);

        public ServiceResult<EducationViewModel> GetEducation(int id);

        public ServiceResult<IEnumerable<EducationViewModel>> GetEducations();
    }
}