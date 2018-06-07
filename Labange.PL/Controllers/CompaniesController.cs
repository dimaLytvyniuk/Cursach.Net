using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Labange.BLL.Interfaces;
using AutoMapper;
using Labange.PL.Infrastructure.Mappers;
using Labange.PL.Models.Company;
using Labange.BLL.DTO.Company;

namespace Labange.PL.Controllers
{
    public class CompaniesController : Controller
    {
        private const string SortNameDesc = "name_desc";
        private const string SortCityAsc = "city_asc";
        private const string SortCityDesc = "city_desc";
        private const string SortQuantityAsc = "quantiy_asc";
        private const string SortQuantityDesc = "quantity_desc";

        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        
        public CompaniesController(ICompanyService companyService)
        {
            _companyService = companyService;
            _mapper = new MapperConfiguration(x => x.AddProfile(new CompanyMapperProfile())).CreateMapper();
        }

        // GET: Companies
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? SortNameDesc : "";
            ViewData["CitySortParm"] = sortOrder == SortCityAsc ? SortCityDesc : SortCityAsc;
            ViewData["QuantitySortParm"] = sortOrder == SortQuantityAsc ? SortQuantityDesc : SortQuantityAsc;

            IEnumerable<CompanyListItemDto> companiesDto = await _companyService.GetAllCompaniesAsync();
            var companies = _mapper.Map<IEnumerable<CompanyListItemDto>, IEnumerable<CompanyListItemModel>>(companiesDto);

            switch (sortOrder)
            {
                case SortNameDesc:
                    companies = companies.OrderByDescending(c => c.Name);
                    break;
                case SortCityAsc:
                    companies = companies.OrderBy(c => c.City);
                    break;
                case SortCityDesc:
                    companies = companies.OrderByDescending(c => c.City);
                    break;
                case SortQuantityAsc:
                    companies = companies.OrderBy(c => c.Quantity);
                    break;
                case SortQuantityDesc:
                    companies = companies.OrderByDescending(c => c.Quantity);
                    break;
                default:
                    companies = companies.OrderBy(c => c.Name);
                    break;
            }

            return View(companies);
        }

        // GET: Companies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyDetailsDto companyDto = await _companyService.GetCompanyAsync((int)id);
            var company = _mapper.Map<CompanyDetailsDto, CompanyDetailsModel>(companyDto);

            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,City,Quantity,About,BusinessArea")] CompanyCreateModel companyModel)
        {
            if (ModelState.IsValid)
            {
                var company = _mapper.Map<CompanyCreateModel, CompanyCreateDto>(companyModel);
                await _companyService.CreateCompanyAsync(company);
                return RedirectToAction(nameof(Index));
            }

            return View(companyModel);
        }

        // GET: Companies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyDetailsDto companyDto = await _companyService.GetCompanyAsync((int)id);
            var company = _mapper.Map<CompanyDetailsDto, CompanyDetailsModel>(companyDto);

            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,City,Quantity,About,BusinessArea")] CompanyDetailsModel companyModel)
        {
            if (id != companyModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var company = _mapper.Map<CompanyDetailsModel, CompanyDetailsDto>(companyModel);
                await _companyService.UpdateCompanyAsync(company);
                return RedirectToAction(nameof(Index));
            }
            return View(companyModel);
        }

        // GET: Companies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CompanyDetailsDto companyDto = await _companyService.GetCompanyAsync((int)id);
            if (companyDto == null)
            {
                return NotFound();
            }
            var company = _mapper.Map<CompanyDetailsDto, CompanyDetailsModel>(companyDto);
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
