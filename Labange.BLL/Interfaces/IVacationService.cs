using Labange.BLL.DTO.Vacation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labange.BLL.Interfaces
{
    public interface IVacationService
    {
        Task<IEnumerable<VacationListItemDto>> GetAllVacationsAsync(string searchFilter = null);
        Task<VacationDetailsDto> CreateVacationAsync(VacationCreateDto vacationDto);
        Task<VacationDetailsDto> GetVacationAsync(int id);
        Task<VacationDetailsDto> UpdateVacationAsync(VacationDetailsDto vacationDto);
        Task DeleteVacationAsync(int id);
    }
}
