using AutoMapper;
using Labange.BLL.DTO.Vacation;
using Labange.BLL.Interfaces;
using Labange.PL.Infrastructure.Mappers;
using Labange.PL.Models.Vacation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Controllers
{
    public class VacationsController : Controller
    {
        private const string SortNameDesc = "name_desc";
        private const string SortSalaryAsc = "salary_asc";
        private const string SortSalaryDesc = "salary_desc";
        private const string SortCompanyNameAsc = "companyName_asc";
        private const string SortCompanyNameDesc = "companyName_desc";

        private readonly IVacationService _vacationService;
        private readonly IMapper _mapper;

        public VacationsController(IVacationService vacationService)
        {
            _vacationService = vacationService;
            _mapper = new MapperConfiguration(x => x.AddProfile(new VacationMapperProfile())).CreateMapper();
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? SortNameDesc : "";
            ViewData["SalarySortParm"] = sortOrder == SortSalaryAsc ? SortSalaryDesc : SortSalaryAsc;
            ViewData["CompanyNameSortParm"] = sortOrder == SortCompanyNameAsc ? SortCompanyNameDesc : SortCompanyNameAsc;

            ViewData["SearchFilter"] = searchString;

            IEnumerable<VacationListItemDto> vacationsDto = await _vacationService.GetAllVacationsAsync(searchString);
            var vacations = _mapper.Map<IEnumerable<VacationListItemDto>, IEnumerable<VacationListItemModel>>(vacationsDto);

            switch (sortOrder)
            {
                case SortNameDesc:
                    vacations = vacations.OrderByDescending(v => v.Name);
                    break;
                case SortSalaryAsc:
                    vacations = vacations.OrderBy(v => v.Salary);
                    break;
                case SortSalaryDesc:
                    vacations = vacations.OrderByDescending(v => v.Salary);
                    break;
                case SortCompanyNameAsc:
                    vacations = vacations.OrderBy(v => v.CompanyName);
                    break;
                case SortCompanyNameDesc:
                    vacations = vacations.OrderByDescending(v => v.CompanyName);
                    break;
                default:
                    vacations = vacations.OrderBy(v => v.Name);
                    break;
            }

            return View(vacations);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VacationDetailsDto vacationDto = await _vacationService.GetVacationAsync((int)id);
            var vacation = _mapper.Map<VacationDetailsDto, VacationDetailsModel>(vacationDto);
            if (vacation == null)
            {
                return NotFound();
            }
            return View(vacation);
        }

        public IActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Name,Salary,Responsibilities,SkillCategory")] VacationCreateModel vacationModel)
        {
            if (ModelState.IsValid)
            {
                vacationModel.CompanyId = id;
                var vacation = _mapper.Map<VacationCreateModel, VacationCreateDto>(vacationModel);
                await _vacationService.CreateVacationAsync(vacation);
                return RedirectToAction(nameof(Index));
            }

            return View(vacationModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VacationDetailsDto vacationDto = await _vacationService.GetVacationAsync((int)id);
            var vacation = _mapper.Map<VacationDetailsDto, VacationDetailsModel>(vacationDto);

            if (vacation == null)
            {
                return NotFound();
            }
            return View(vacation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Salary,Responsibilities,SkillCategory")] VacationDetailsModel vacationModel)
        {
            if (id != vacationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var vacation = _mapper.Map<VacationDetailsModel, VacationDetailsDto>(vacationModel);
                await _vacationService.UpdateVacationAsync(vacation);
                return RedirectToAction(nameof(Index));
            }
            return View(vacationModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VacationDetailsDto vacationDto = await _vacationService.GetVacationAsync((int)id);
            if (vacationDto == null)
            {
                return NotFound();
            }
            var vacation = _mapper.Map<VacationDetailsDto, VacationDetailsModel>(vacationDto);
            return View(vacation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _vacationService.DeleteVacationAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
