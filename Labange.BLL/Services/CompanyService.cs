using AutoMapper;
using Labange.BLL.DTO.Company;
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
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new MapperConfiguration(x => x.AddProfile(new CompanyMapperProfile())).CreateMapper();
        }

        public async Task<CompanyDetailsDto> CreateCompanyAsync(CompanyCreateDto companyDto)
        {
            using (_unitOfWork)
            {
                var companyRepository = _unitOfWork.CompanyRepository;

                var company = _mapper.Map<CompanyCreateDto, Company>(companyDto);
                companyRepository.Add(company);
                await _unitOfWork.SaveAsync();
                return await GetCompanyAsync(company.Id);
            }
        }

        public async Task DeleteCompanyAsync(int id)
        {
            using (_unitOfWork)
            {
                var companyRepository = _unitOfWork.CompanyRepository;
                var company = await companyRepository.FindAsync(x => x.Id == id);

                if (company != null)
                {
                    companyRepository.Delete(company);
                    await _unitOfWork.SaveAsync();
                }
            }
        }

        public async Task<IEnumerable<CompanyListItemDto>> GetAllCompaniesAsync()
        {
            using (_unitOfWork)
            {
                var companyRepository = _unitOfWork.CompanyRepository;
                IEnumerable<Company> companies = await companyRepository.GetAllAsync();
                var companiesDto = _mapper.Map<IEnumerable<Company>, IEnumerable<CompanyListItemDto>>(companies);
                return companiesDto;
            }
        }

        public async Task<CompanyDetailsDto> GetCompanyAsync(int id)
        {
            using (_unitOfWork)
            {
                var companyRepository = _unitOfWork.CompanyRepository;
                var company = await companyRepository.FindAsync(x => x.Id == id);
                if (company == null)
                    return null;
                var companyDto = _mapper.Map<Company, CompanyDetailsDto>(company);
                return companyDto;
            }
        }

        public async Task<CompanyDetailsDto> UpdateCompanyAsync(CompanyDetailsDto companyDto)
        {
            using (_unitOfWork)
            {
                var companyRepository = _unitOfWork.CompanyRepository;

                var company = await companyRepository.FindAsync(x => x.Id == companyDto.Id);
                company = _mapper.Map<CompanyDetailsDto, Company>(companyDto, company);
                companyRepository.Update(company);
                await _unitOfWork.SaveAsync();

                return _mapper.Map<Company, CompanyDetailsDto>(company);
            }
        }
    }
}
