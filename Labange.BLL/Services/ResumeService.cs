using AutoMapper;
using Labange.BLL.DTO.Resume;
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
    public class ResumeService : IResumeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResumeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new MapperConfiguration(x => x.AddProfile(new ResumeMapperProfile())).CreateMapper();
        }

        public async Task<bool> IsExistAsync(int unemployedId)
        {
            using (_unitOfWork)
            {
                var resumeRepository = _unitOfWork.ResumeRepository;
                var resume = await resumeRepository.FindAsync(x => x.UnemployedId == unemployedId);
                return resume == null ? false : true;
            }
        }

        public async Task<ResumeDetailsDto> CreateResumeAsync(ResumeCreateDto resumeDto)
        {
            using (_unitOfWork)
            {
                var resumeRepository = _unitOfWork.ResumeRepository;

                var resume = _mapper.Map<ResumeCreateDto, Resume>(resumeDto);
                resumeRepository.Add(resume);
                await _unitOfWork.SaveAsync();
                return await GetResumeAsync(resume.Id);
            }
        }

        public async Task DeleteResumeAsync(int id)
        {
            using (_unitOfWork)
            {
                var resumeRepository = _unitOfWork.ResumeRepository;
                var resume = await resumeRepository.FindAsync(x => x.Id == id);

                if (resume != null)
                {
                    resumeRepository.Delete(resume);
                    await _unitOfWork.SaveAsync();
                }
            }
        }

        public async Task<IEnumerable<ResumeListItemDto>> GetAllResumesAsync()
        {
            using (_unitOfWork)
            {
                var resumeRepository = _unitOfWork.ResumeRepository;
                IEnumerable<Resume> resumes = await resumeRepository.GetAllAsync();
                var resumesDto = _mapper.Map<IEnumerable<Resume>, IEnumerable<ResumeListItemDto>>(resumes);
                return resumesDto;
            }
        }

        public async Task<ResumeDetailsDto> GetResumeAsync(int id)
        {
            using (_unitOfWork)
            {
                var resumeRepository = _unitOfWork.ResumeRepository;
                var resume = await resumeRepository.FindAsync(x => x.Id == id);
                if (resume == null)
                    return null;
                var resumeDto = _mapper.Map<Resume, ResumeDetailsDto>(resume);
                return resumeDto;
            }
        }

        public async Task<ResumeDetailsDto> UpdateResumeAsync(ResumeDetailsDto resumeDto)
        {
            using (_unitOfWork)
            {
                var resumeRepository = _unitOfWork.ResumeRepository;

                var resume = await resumeRepository.FindAsync(x => x.Id == resumeDto.Id);
                resume = _mapper.Map<ResumeDetailsDto, Resume>(resumeDto, resume);
                resumeRepository.Update(resume);
                await _unitOfWork.SaveAsync();

                return _mapper.Map<Resume, ResumeDetailsDto>(resume);
            }
        }
    }
}
