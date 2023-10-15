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
        private readonly IMapper _mapper;
        private readonly IRepository<Tool> _toolRepository;

        public ToolService(IRepository<Tool> toolRepository, IMapper mapper)
        {
            _toolRepository = toolRepository;
            _mapper = mapper;
        }

        public ServiceResult<bool> AddTool(ToolViewModel tool)
        {
            try
            {
                _toolRepository.Add(_mapper.Map<Tool>(tool));
                _toolRepository.SaveChanges();

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
                _toolRepository.Remove(id);
                _toolRepository.SaveChanges();

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

        public ServiceResult<bool> UpdateTool(ToolViewModel tool)
        {
            try
            {
                _toolRepository.Update(_mapper.Map<Tool>(tool));
                _toolRepository.SaveChanges();

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
                var tool = _toolRepository.Find(id);

                return new ServiceResult<ToolViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<ToolViewModel>(tool)
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
                var tools = _toolRepository.GetAll();

                return new ServiceResult<IEnumerable<ToolViewModel>>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<ToolViewModel>>(tools)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<ToolViewModel>> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}