using AutoMapper;
using Common;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Work.Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class WorkService : IWorkService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Position> _positionRepository;
        private readonly IRepository<Work> _workRepository;

        public WorkService(IRepository<Work> workRepository, IMapper mapper, IRepository<Position> positionRepository)
        {
            _workRepository = workRepository;
            _mapper = mapper;
            _positionRepository = positionRepository;
        }

        public ServiceResult<bool> AddWork(WorkViewModel work)
        {
            try
            {
                _workRepository.Add(_mapper.Map<Work>(work));

                _workRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<bool> DeleteWork(int id)
        {
            try
            {
                _positionRepository.Remove(x => x.WorkId == id);
                _workRepository.Remove(id);

                _workRepository.SaveChanges();
                _positionRepository.SaveChanges();

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

        public ServiceResult<bool> UpdateWork(WorkViewModel work)
        {
            try
            {
                _workRepository.Update(_mapper.Map<Work>(work));

                _workRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<WorkViewModel> GetWork(int id)
        {
            try
            {
                var work = _workRepository.Find(id);

                return new ServiceResult<WorkViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<WorkViewModel>(work)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<WorkViewModel> { Message = e.Message, IsSuccess = false };
            }
        }

        public ServiceResult<IEnumerable<WorkViewModel>> GetWorks()
        {
            try
            {
                var works = _workRepository.GetAll();

                return new ServiceResult<IEnumerable<WorkViewModel>>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<WorkViewModel>>(works)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<WorkViewModel>> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}