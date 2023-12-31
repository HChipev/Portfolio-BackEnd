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
        private readonly IRepository<Framework> _frameworkRepository;
        private readonly IMapper _mapper;

        public FrameworkService(IRepository<Framework> frameworkRepository, IMapper mapper)
        {
            _frameworkRepository = frameworkRepository;
            _mapper = mapper;
        }

        public ServiceResult<bool> AddFramework(FrameworkViewModel framework)
        {
            try
            {
                _frameworkRepository.Add(_mapper.Map<Framework>(framework));
                _frameworkRepository.SaveChanges();

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
                _frameworkRepository.Remove(id);
                _frameworkRepository.SaveChanges();

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

        public ServiceResult<bool> UpdateFramework(FrameworkViewModel framework)
        {
            try
            {
                _frameworkRepository.Update(_mapper.Map<Framework>(framework));
                _frameworkRepository.SaveChanges();

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
                var framework = _frameworkRepository.Find(id);

                return new ServiceResult<FrameworkViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<FrameworkViewModel>(framework)
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
                var frameworks = _frameworkRepository.GetAll();

                return new ServiceResult<IEnumerable<FrameworkViewModel>>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<FrameworkViewModel>>(frameworks)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<FrameworkViewModel>> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}