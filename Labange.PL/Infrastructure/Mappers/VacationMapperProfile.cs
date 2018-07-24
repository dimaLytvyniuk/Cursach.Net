using AutoMapper;
using Labange.BLL.DTO.Vacation;
using Labange.PL.Models.Vacation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Infrastructure.Mappers
{
    public class VacationMapperProfile : Profile
    {
        public VacationMapperProfile()
        {
            CreateMap<VacationCreateModel, VacationCreateDto>();
            CreateMap<VacationListItemDto, VacationListItemModel>();
            CreateMap<VacationDetailsDto, VacationDetailsModel>();
            CreateMap<VacationDetailsModel, VacationDetailsDto>();
        }
    }
}
