using AutoMapper;
using Common;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Framework.Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class FrameworkService : IFrameworkService
    {
        private readonly IRepository<Framework> _languageRepository;
        private readonly IMapper _mapper;

        public FrameworkService(IRepository<Framework> languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public ServiceResult<bool> AddFramework(FrameworkViewModel language)
        {
            try
            {
                _languageRepository.Add(_mapper.Map<Framework>(language));
                _languageRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<bool> DeleteFramework(int id)
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

        public ServiceResult<bool> UpdateFramework(FrameworkViewModel language)
        {
            try
            {
                _languageRepository.Update(_mapper.Map<Framework>(language));
                _languageRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<FrameworkViewModel> GetFramework(int id)
        {
            try
            {
                var language = _languageRepository.Find(id);

                return new ServiceResult<FrameworkViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<FrameworkViewModel>(language)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<FrameworkViewModel> { Message = e.Message, IsSuccess = false };
            }
        }

        public ServiceResult<IEnumerable<FrameworkViewModel>> GetFrameworks()
        {
            try
            {
                var languages = _languageRepository.GetAll();

                return new ServiceResult<IEnumerable<FrameworkViewModel>>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<FrameworkViewModel>>(languages)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<FrameworkViewModel>> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}