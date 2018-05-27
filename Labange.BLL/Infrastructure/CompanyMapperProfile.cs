using AutoMapper;
using Labange.BLL.DTO.Company;
using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.Infrastructure
{
    public class CompanyMapperProfile : Profile
    {
        public CompanyMapperProfile()
        {
            CreateMap<CompanyCreateDto, Company>();
            CreateMap<CompanyDetailsDto, Company>();
            CreateMap<Company, CompanyListItemDto>();
            CreateMap<Company, CompanyDetailsDto>();
        }
    }
}
