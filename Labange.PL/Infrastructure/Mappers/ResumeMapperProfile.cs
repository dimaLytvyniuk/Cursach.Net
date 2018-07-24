using AutoMapper;
using Labange.BLL.DTO.Resume;
using Labange.PL.Models.Resume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Infrastructure.Mappers
{
    public class ResumeMapperProfile : Profile
    {
        public ResumeMapperProfile()
        {
            CreateMap<ResumeCreateModel, ResumeCreateDto>();
            CreateMap<ResumeListItemDto, ResumeListItemModel>();
            CreateMap<ResumeDetailsDto, ResumeDetailsModel>();
            CreateMap<ResumeDetailsModel, ResumeDetailsDto>();
        }
    }
}
