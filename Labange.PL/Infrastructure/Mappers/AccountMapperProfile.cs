using AutoMapper;
using Labange.BLL.DTO;
using Labange.PL.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Labange.PL.Infrastructure.Mappers
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<RegisterModel, UserRegistrationDto>();
            CreateMap<LoginModel, UserLoginDto>();
        }
    }
}
