using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Labange.BLL.DTO.Resume;
using Labange.BLL.Interfaces;
using Labange.PL.Infrastructure.Mappers;
using Labange.PL.Models.Resume;
using Microsoft.AspNetCore.Mvc;

namespace Labange.PL.Controllers
{
    public class ResumesController : Controller
    {
        private const string SortNameDesc = "name_desc";
        private const string SortExperienceYearsAsc = "experienceYears_asc";
        private const string SortExperienceYearsDesc = "experienceYears_desc";
        private const string SortSkillCategoryAsc = "skillCategory_asc";
        private const string SortSkillCategoryDesc = "skillCategory_desc";

        private readonly IResumeService _resumeService;
        private readonly IMapper _mapper;

        public ResumesController(IResumeService resumeService)
        {
            _resumeService = resumeService;
            _mapper = new MapperConfiguration(x => x.AddProfile(new ResumeMapperProfile())).CreateMapper();
        }

        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? SortNameDesc : "";
            ViewData["ExperienceYearsSortParm"] = sortOrder == SortExperienceYearsAsc ? SortExperienceYearsDesc : SortExperienceYearsAsc;
            ViewData["SkillCategorySortParm"] = sortOrder == SortSkillCategoryAsc ? SortSkillCategoryDesc : SortSkillCategoryAsc;

            IEnumerable<ResumeListItemDto> resumesDto = await _resumeService.GetAllResumesAsync();
            var resumes = _mapper.Map<IEnumerable<ResumeListItemDto>, IEnumerable<ResumeListItemModel>>(resumesDto);

            switch (sortOrder)
            {
                case SortNameDesc:
                    resumes = resumes.OrderByDescending(r => r.Name);
                    break;
                case SortExperienceYearsAsc:
                    resumes = resumes.OrderBy(r => r.ExperienceYears);
                    break;
                case SortExperienceYearsDesc:
                    resumes = resumes.OrderByDescending(r => r.ExperienceYears);
                    break;
                case SortSkillCategoryAsc:
                    resumes = resumes.OrderBy(r => r.SkillCategory);
                    break;
                case SortSkillCategoryDesc:
                    resumes = resumes.OrderByDescending(r => r.SkillCategory);
                    break;
                default:
                    resumes = resumes.OrderBy(r => r.Name);
                    break;
            }

            return View(resumes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResumeDetailsDto resumeDto = await _resumeService.GetResumeAsync((int)id);
            var resume = _mapper.Map<ResumeDetailsDto, ResumeDetailsModel>(resumeDto);
            if (resume == null)
            {
                return NotFound();
            }
            return View(resume);
        }

        public async Task<IActionResult> Create(int id)
        {
            bool isExist = await _resumeService.IsExistAsync(id);
            if (isExist)
                return Redirect($"~/Resumes/Details/{id}");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("About,ExperienceYears,Skills,PlacesOfWork,SkillCategory")] ResumeCreateModel resumeModel)
        {
            if (ModelState.IsValid)
            {
                resumeModel.UnemployedId = id;
                var resume = _mapper.Map<ResumeCreateModel, ResumeCreateDto>(resumeModel);
                await _resumeService.CreateResumeAsync(resume);
                return RedirectToAction(nameof(Index));
            }

            return View(resumeModel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResumeDetailsDto resumeDto = await _resumeService.GetResumeAsync((int)id);
            var resume = _mapper.Map<ResumeDetailsDto, ResumeDetailsModel>(resumeDto);

            if (resume == null)
            {
                return NotFound();
            }
            return View(resume);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,About,ExperienceYears,Skills,PlacesOfWork,SkillCategory")] ResumeDetailsModel resumeModel)
        {
            if (id != resumeModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var resume = _mapper.Map<ResumeDetailsModel, ResumeDetailsDto>(resumeModel);
                await _resumeService.UpdateResumeAsync(resume);
                return RedirectToAction(nameof(Index));
            }
            return View(resumeModel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ResumeDetailsDto resumeDto = await _resumeService.GetResumeAsync((int)id);
            if (resumeDto == null)
            {
                return NotFound();
            }
            var resume = _mapper.Map<ResumeDetailsDto, ResumeDetailsModel>(resumeDto);
            return View(resume);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _resumeService.DeleteResumeAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
