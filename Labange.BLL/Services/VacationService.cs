using AutoMapper;
using Labange.BLL.DTO.Vacation;
using Labange.BLL.Infrastructure;
using Labange.BLL.Interfaces;
using Labange.DAL.Entities;
using Labange.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labange.BLL.Services
{
    public class VacationService : IVacationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VacationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new MapperConfiguration(x => x.AddProfile(new VacationMapperProfile())).CreateMapper();
        }

        public async Task<VacationDetailsDto> CreateVacationAsync(VacationCreateDto vacationDto)
        {
            using (_unitOfWork)
            {
                var vacationRepository = _unitOfWork.VacationRepository;

                var vacation = _mapper.Map<VacationCreateDto, Vacation>(vacationDto);
                vacationRepository.Add(vacation);
                await _unitOfWork.SaveAsync();
                return await GetVacationAsync(vacation.Id);
            }
        }

        public async Task DeleteVacationAsync(int id)
        {
            using (_unitOfWork)
            {
                var vacationRepository = _unitOfWork.VacationRepository;
                var vacation = await vacationRepository.FindAsync(x => x.Id == id);

                if (vacation != null)
                {
                    vacationRepository.Delete(vacation);
                    await _unitOfWork.SaveAsync();
                }
            }
        }

        public async Task<IEnumerable<VacationListItemDto>> GetAllVacationsAsync(string searchFilter = null)
        {
            using (_unitOfWork)
            {
                var vacationRepository = _unitOfWork.VacationRepository;
                IEnumerable<Vacation> vacations;

                if (String.IsNullOrEmpty(searchFilter))
                {
                    vacations = await vacationRepository.GetAllAsync();
                }
                else
                {
                    searchFilter = searchFilter.ToUpper();
                    vacations = vacationRepository.FindAll(x =>
                        x.Name.ToUpper().Contains(searchFilter) || x.Company.Name.ToUpper().Contains(searchFilter) ||
                        x.SkillCategory.ToString().ToUpper().Contains(searchFilter));
                }

                var vacationsDto = _mapper.Map<IEnumerable<Vacation>, IEnumerable<VacationListItemDto>>(vacations);
                return vacationsDto;
            }
        }

        public async Task<VacationDetailsDto> GetVacationAsync(int id)
        {
            using (_unitOfWork)
            {
                var vacationRepository = _unitOfWork.VacationRepository;
                var vacation = await vacationRepository.FindAsync(x => x.Id == id);
                if (vacation == null)
                    return null;
                var vacationDto = _mapper.Map<Vacation, VacationDetailsDto>(vacation);
                return vacationDto;
            }
        }

        public async Task<VacationDetailsDto> UpdateVacationAsync(VacationDetailsDto vacationDto)
        {
            using (_unitOfWork)
            {
                var vacationRepository = _unitOfWork.VacationRepository;

                var vacation = await vacationRepository.FindAsync(x => x.Id == vacationDto.Id);
                vacation = _mapper.Map<VacationDetailsDto, Vacation>(vacationDto, vacation);
                vacationRepository.Update(vacation);
                await _unitOfWork.SaveAsync();

                return _mapper.Map<Vacation, VacationDetailsDto>(vacation);
            }
        }
    }
}
