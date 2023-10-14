using AutoMapper;
using Common;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Tool.Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class ToolService : IToolService
    {
        private readonly IRepository<Tool> _languageRepository;
        private readonly IMapper _mapper;

        public ToolService(IRepository<Tool> languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public ServiceResult<bool> AddTool(ToolViewModel language)
        {
            try
            {
                _languageRepository.Add(_mapper.Map<Tool>(language));
                _languageRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<bool> DeleteTool(int id)
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

        public ServiceResult<bool> UpdateTool(ToolViewModel language)
        {
            try
            {
                _languageRepository.Update(_mapper.Map<Tool>(language));
                _languageRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<ToolViewModel> GetTool(int id)
        {
            try
            {
                var language = _languageRepository.Find(id);

                return new ServiceResult<ToolViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<ToolViewModel>(language)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<ToolViewModel> { Message = e.Message, IsSuccess = false };
            }
        }

        public ServiceResult<IEnumerable<ToolViewModel>> GetTools()
        {
            try
            {
                var languages = _languageRepository.GetAll();

                return new ServiceResult<IEnumerable<ToolViewModel>>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<ToolViewModel>>(languages)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<ToolViewModel>> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}