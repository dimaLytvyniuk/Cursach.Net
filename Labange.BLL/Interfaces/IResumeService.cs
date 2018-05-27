using Labange.BLL.DTO.Resume;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labange.BLL.Interfaces
{
    public interface IResumeService
    {
        Task<IEnumerable<ResumeListItemDto>> GetAllResumesAsync();
        Task<ResumeDetailsDto> CreateResumeAsync(ResumeCreateDto ResumeDto);
        Task<ResumeDetailsDto> GetResumeAsync(int id);
        Task<ResumeDetailsDto> UpdateResumeAsync(ResumeDetailsDto ResumeDto);
        Task DeleteResumeAsync(int id);
        Task<bool> IsExistAsync(int unemployedId);
    }
}
