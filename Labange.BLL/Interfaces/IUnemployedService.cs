using Labange.BLL.DTO.Unemployed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labange.BLL.Interfaces
{
    public interface IUnemployedService
    {
        Task<IEnumerable<UnemployedDto>> GetAllUnemployedsAsync(string searchFilter = null);
        Task<UnemployedDto> CreateUnemployedAsync(UnemployedCreateDto unemployedDto);
        Task<UnemployedDto> GetUnemployedAsync(int id);
        Task<UnemployedDto> UpdateUnemployedAsync(int id, UnemployedCreateDto unemployedDto);
        Task DeleteUnemployedAsync(int id);
    }
}
