using AutoMapper;
using Labange.BLL.DTO.Resume;
using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.Infrastructure
{
    public class ResumeMapperProfile : Profile
    {
        public ResumeMapperProfile()
        {
            CreateMap<ResumeCreateDto, Resume>();
            CreateMap<ResumeDetailsDto, Resume>()
                .ForMember("UnemployedId", opt => opt.Ignore());
            CreateMap<Resume, ResumeListItemDto>()
                .ForMember("Name", opt => 
                    opt.MapFrom(r => $"{r.Unemployed.FirstName} {r.Unemployed.LastName}"));
            CreateMap<Resume, ResumeDetailsDto>()
                .ForMember("Name", opt =>
                    opt.MapFrom(r => $"{r.Unemployed.FirstName} {r.Unemployed.LastName}"));
        }
    }
}