using AutoMapper;
using Common;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Language.Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> _languageRepository;
        private readonly IMapper _mapper;

        public LanguageService(IRepository<Language> languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public ServiceResult<bool> AddLanguage(LanguageViewModel language)
        {
            try
            {
                _languageRepository.Add(_mapper.Map<Language>(language));
                _languageRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<bool> DeleteLanguage(int id)
        {
            try
            {
                _languageRepository.Remove(id);
                _languageRepository.SaveChanges();

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

        public ServiceResult<bool> UpdateLanguage(LanguageViewModel language)
        {
            try
            {
                _languageRepository.Update(_mapper.Map<Language>(language));
                _languageRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<LanguageViewModel> GetLanguage(int id)
        {
            try
            {
                var language = _languageRepository.Find(id);

                return new ServiceResult<LanguageViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<LanguageViewModel>(language)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<LanguageViewModel> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}