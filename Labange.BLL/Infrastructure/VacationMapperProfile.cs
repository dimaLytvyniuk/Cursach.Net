using AutoMapper;
using Labange.BLL.DTO.Vacation;
using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.Infrastructure
{
    public class VacationMapperProfile : Profile
    {
        public VacationMapperProfile()
        {
            CreateMap<VacationCreateDto, Vacation>();
            CreateMap<VacationDetailsDto, Vacation>()
                .ForMember("CompanyId", opt => opt.Ignore());
            CreateMap<Vacation, VacationListItemDto>()
                .ForMember("CompanyName", opt => opt.MapFrom(v => v.Company.Name));
            CreateMap<Vacation, VacationDetailsDto>()
                .ForMember("CompanyName", opt => opt.MapFrom(v => v.Company.Name));
        }
    }
}
