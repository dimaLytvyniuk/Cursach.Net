using Labange.BLL.DTO.Company;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labange.BLL.Interfaces
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyListItemDto>> GetAllCompaniesAsync();
        Task<CompanyDetailsDto> CreateCompanyAsync(CompanyCreateDto companyDto);
        Task<CompanyDetailsDto> GetCompanyAsync(int id);
        Task<CompanyDetailsDto> UpdateCompanyAsync(CompanyDetailsDto companyDto);
        Task DeleteCompanyAsync(int id);
    }
}
