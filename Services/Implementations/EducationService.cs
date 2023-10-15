using AutoMapper;
using Common;
using Data.Entities;
using Data.Repository;
using Data.ViewModels.Education.Models;
using Services.Interfaces;

namespace Services.Implementations
{
    public class EducationService : IEducationService
    {
        private readonly IRepository<Education> _educationRepository;
        private readonly IMapper _mapper;

        public EducationService(IRepository<Education> educationRepository, IMapper mapper)
        {
            _educationRepository = educationRepository;
            _mapper = mapper;
        }

        public ServiceResult<bool> AddEducation(EducationViewModel education)
        {
            try
            {
                _educationRepository.Add(_mapper.Map<Education>(education));
                _educationRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<bool> DeleteEducation(int id)
        {
            try
            {
                _educationRepository.Remove(id);
                _educationRepository.SaveChanges();

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

        public ServiceResult<bool> UpdateEducation(EducationViewModel education)
        {
            try
            {
                _educationRepository.Update(_mapper.Map<Education>(education));
                _educationRepository.SaveChanges();

                return new ServiceResult<bool> { Message = "", IsSuccess = true, Data = true };
            }
            catch (Exception e)
            {
                return new ServiceResult<bool> { Message = e.Message, IsSuccess = false, Data = false };
            }
        }

        public ServiceResult<EducationViewModel> GetEducation(int id)
        {
            try
            {
                var education = _educationRepository.Find(id);

                return new ServiceResult<EducationViewModel>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<EducationViewModel>(education)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<EducationViewModel> { Message = e.Message, IsSuccess = false };
            }
        }

        public ServiceResult<IEnumerable<EducationViewModel>> GetEducations()
        {
            try
            {
                var educations = _educationRepository.GetAll();

                return new ServiceResult<IEnumerable<EducationViewModel>>
                {
                    Message = "",
                    IsSuccess = true,
                    Data = _mapper.Map<IEnumerable<EducationViewModel>>(educations)
                };
            }
            catch (Exception e)
            {
                return new ServiceResult<IEnumerable<EducationViewModel>> { Message = e.Message, IsSuccess = false };
            }
        }
    }
}