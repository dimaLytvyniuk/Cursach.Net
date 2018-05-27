using AutoMapper;
using Labange.BLL.DTO.Unemployed;
using Labange.PL.Infrastructure.Mappers;
using Labange.BLL.Interfaces;
using Labange.PL.Models.Unemployed;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Controllers
{
    public class UnemployedsController : Controller
    {
        private const string SortLastNameDesc = "lastName_desc";
        private const string SortFirstNameAsc = "firstName_asc";
        private const string SortFirstNameDesc = "firstName_desc";
        private const string SortBirthdayAsc = "birthday_asc";
        private const string SortBirthdayDesc = "birthday_desc";
        private const string SortCityAsc = "city_asc";
        private const string SortCityDesc = "city_desc";

        private readonly IUnemployedService _unemployedService;
        private readonly IMapper _mapper;

        public UnemployedsController(IUnemployedService unemployedService)
        {
            _unemployedService = unemployedService;
            _mapper = new MapperConfiguration(x => x.AddProfile(new UnemployedMapperProfile())).CreateMapper();
        }

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["LastNameSortParm"] = String.IsNullOrEmpty(sortOrder) ? SortLastNameDesc : "";
            ViewData["FirstNameSortParm"] = sortOrder == SortFirstNameAsc ? SortFirstNameDesc : SortFirstNameAsc;
            ViewData["BirthdaySortParm"] = sortOrder == SortBirthdayAsc ? SortBirthdayDesc : SortBirthdayAsc;
            ViewData["CitySortParm"] = sortOrder == SortCityAsc ? SortCityDesc : SortCityAsc;

            ViewData["SearchFilter"] = searchString;

            IEnumerable<UnemployedDto> unemployedsDto = await _unemployedService.GetAllUnemployedsAsync(searchString);
            var unemployeds = _mapper.Map<IEnumerable<UnemployedDto>, IEnumerable<UnemployedModel>>(unemployedsDto);

            switch (sortOrder)
            {
                case SortLastNameDesc:
                    unemployeds = unemployeds.OrderByDescending(u => u.LastName);
                    break;
                case SortFirstNameAsc:
                    unemployeds = unemployeds.OrderBy(u => u.FirstName);
                    break;
                case SortFirstNameDesc:
                    unemployeds = unemployeds.OrderByDescending(u => u.FirstName);
                    break;
                case SortBirthdayAsc:
                    unemployeds = unemployeds.OrderBy(u => u.Birthday);
                    break;
                case SortBirthdayDesc:
                    unemployeds = unemployeds.OrderByDescending(u => u.Birthday);
                    break;
                case SortCityAsc:
                    unemployeds = unemployeds.OrderBy(u => u.City);
                    break;
                case SortCityDesc:
                    unemployeds = unemployeds.OrderByDescending(u => u.City);
                    break;
                default:
                    unemployeds = unemployeds.OrderBy(u => u.LastName);
                    break;
            }

            return View(unemployeds);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UnemployedDto unemployedDto = await _unemployedService.GetUnemployedAsync((int)id);
            var unemployed = _mapper.Map<UnemployedDto, UnemployedModel>(unemployedDto);
            if (unemployed == null)
            {
                return NotFound();
            }
            return View(unemployed);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,City,Birthday")] UnemployedCreateModel unemployedModel)
        {
            if (ModelState.IsValid)
            {
                var unemployed = _mapper.Map<UnemployedCreateModel, UnemployedCreateDto>(unemployedModel);
                await _unemployedService.CreateUnemployedAsync(unemployed);
                return RedirectToAction(nameof(Index));
            }

            return View(unemployedModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UnemployedDto unemployedDto = await _unemployedService.GetUnemployedAsync((int)id);
            var unemployed = _mapper.Map<UnemployedDto, UnemployedCreateModel>(unemployedDto);

            if (unemployed == null)
            {
                return NotFound();
            }
            return View(unemployed);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,City,Birthday")] UnemployedCreateModel unemployedModel)
        {
            if (ModelState.IsValid)
            {
                var unemployed = _mapper.Map<UnemployedCreateModel, UnemployedCreateDto>(unemployedModel);
                await _unemployedService.UpdateUnemployedAsync(id, unemployed);
                return RedirectToAction(nameof(Index));
            }
            return View(unemployedModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UnemployedDto unemployedDto = await _unemployedService.GetUnemployedAsync((int)id);
            if (unemployedDto == null)
            {
                return NotFound();
            }
            var unemployed = _mapper.Map<UnemployedDto, UnemployedModel>(unemployedDto);
            return View(unemployed);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unemployedService.DeleteUnemployedAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
