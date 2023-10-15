using Common;
using Data.ViewModels.Language.Models;
using Services.Abstract;

namespace Services.Interfaces
{
    public interface ILanguageService : IService
    {
        public ServiceResult<bool> AddLanguage(LanguageViewModel language);

        public ServiceResult<bool> DeleteLanguage(int id);

        public ServiceResult<bool> UpdateLanguage(LanguageViewModel language);

        public ServiceResult<LanguageViewModel> GetLanguage(int id);

        public ServiceResult<IEnumerable<LanguageViewModel>> GetLanguages();
    }
}