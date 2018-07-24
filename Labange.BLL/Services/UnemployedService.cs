using AutoMapper;
using Labange.BLL.DTO.Unemployed;
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
    public class UnemployedService : IUnemployedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UnemployedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new MapperConfiguration(x => x.AddProfile(new UnemployedMapperProfile())).CreateMapper();
        }

        public async Task<UnemployedDto> CreateUnemployedAsync(UnemployedCreateDto unemployedDto)
        {
            using (_unitOfWork)
            {
                var unemployedRepository = _unitOfWork.UnemployedRepository;

                var unemployed = _mapper.Map<UnemployedCreateDto, Unemployed>(unemployedDto);
                unemployedRepository.Add(unemployed);
                await _unitOfWork.SaveAsync();
                return await GetUnemployedAsync(unemployed.Id);
            }
        }

        public async Task DeleteUnemployedAsync(int id)
        {
            using (_unitOfWork)
            {
                var unemployedRepository = _unitOfWork.UnemployedRepository;
                var unemployed = await unemployedRepository.FindAsync(x => x.Id == id);

                if (unemployed != null)
                {
                    unemployedRepository.Delete(unemployed);
                    await _unitOfWork.SaveAsync();
                }
            }
        }

        public async Task<IEnumerable<UnemployedDto>> GetAllUnemployedsAsync(string searchFilter = null)
        {
            using (_unitOfWork)
            {
                var unemployedRepository = _unitOfWork.UnemployedRepository;
                IEnumerable<Unemployed> unemployeds;

                if (String.IsNullOrEmpty(searchFilter))
                {
                    unemployeds = await unemployedRepository.GetAllAsync();
                }
                else
                {
                    searchFilter = searchFilter.ToUpper();
                    unemployeds = unemployedRepository.FindAll(x =>
                        x.FirstName.ToUpper().Contains(searchFilter) || x.LastName.ToUpper().Contains(searchFilter) || 
                        x.City.ToUpper().Contains(searchFilter));
                }

                var unemployedsDto = _mapper.Map<IEnumerable<Unemployed>, IEnumerable<UnemployedDto>>(unemployeds);
                return unemployedsDto;
            }
        }

        public async Task<UnemployedDto> GetUnemployedAsync(int id)
        {
            using (_unitOfWork)
            {
                var unemployedRepository = _unitOfWork.UnemployedRepository;
                var unemployed = await unemployedRepository.FindAsync(x => x.Id == id);
                if (unemployed == null)
                    return null;
                var unemployedDto = _mapper.Map<Unemployed, UnemployedDto>(unemployed);
                return unemployedDto;
            }
        }

        public async Task<UnemployedDto> UpdateUnemployedAsync(int id, UnemployedCreateDto unemployedDto)
        {
            using (_unitOfWork)
            {
                var unemployedRepository = _unitOfWork.UnemployedRepository;

                var unemployed = await unemployedRepository.FindAsync(x => x.Id == id);
                if (unemployed == null)
                {
                    return null;
                }

                unemployed = _mapper.Map<UnemployedCreateDto, Unemployed>(unemployedDto, unemployed);
                unemployedRepository.Update(unemployed);
                await _unitOfWork.SaveAsync();

                return _mapper.Map<Unemployed, UnemployedDto>(unemployed);
            }
        }
    }
}
