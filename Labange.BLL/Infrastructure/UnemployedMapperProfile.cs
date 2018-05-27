using AutoMapper;
using Labange.BLL.DTO.Unemployed;
using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.Infrastructure
{
    public class UnemployedMapperProfile : Profile
    {
        public UnemployedMapperProfile()
        {
            CreateMap<UnemployedCreateDto, Unemployed>();
            CreateMap<Unemployed, UnemployedDto>();
        }
    }
}
