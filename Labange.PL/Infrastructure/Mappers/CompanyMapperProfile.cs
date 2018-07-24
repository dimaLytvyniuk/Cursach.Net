using AutoMapper;
using Labange.BLL.DTO.Company;
using Labange.PL.Models.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Infrastructure.Mappers
{
    public class CompanyMapperProfile : Profile
    {
        public CompanyMapperProfile()
        {
            CreateMap<CompanyCreateModel, CompanyCreateDto>();
            CreateMap<CompanyListItemDto, CompanyListItemModel>();
            CreateMap<CompanyDetailsDto, CompanyDetailsModel>();
            CreateMap<CompanyDetailsModel, CompanyDetailsDto>();
        }
    }
}
