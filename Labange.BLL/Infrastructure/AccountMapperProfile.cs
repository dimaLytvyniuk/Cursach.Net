using AutoMapper;
using Labange.BLL.DTO;
using Labange.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labange.BLL.Infrastructure
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            CreateMap<UserRegistrationDto, User>();
            CreateMap<User, UserProfileDto>();
            CreateMap<UserRegistrationDto, UserLoginDto>();
        }
    }
}
