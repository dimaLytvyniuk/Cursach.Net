using AutoMapper;
using Labange.BLL.DTO.Unemployed;
using Labange.PL.Models.Unemployed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Infrastructure.Mappers
{
    public class UnemployedMapperProfile : Profile
    {
        public UnemployedMapperProfile()
        {
            CreateMap<UnemployedCreateModel, UnemployedCreateDto>();
            CreateMap<UnemployedDto, UnemployedCreateModel>();
            CreateMap<UnemployedDto, UnemployedModel>();
        }

    }
}
