﻿using AutoMapper;
using Labange.BLL.DTO;
using Labange.BLL.Infrastructure;
using Labange.BLL.Interfaces;
using Labange.DAL.Entities;
using Labange.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labange.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new MapperConfiguration(x => x.AddProfile(new AccountMapperProfile())).CreateMapper();
        }

        public async Task<UserProfileDto> GetUserProfileInfo(UserLoginDto userLoginDto)
        {
            using (_unitOfWork)
            {
                var userRepository = _unitOfWork.UserRepository;

                var user = await userRepository.FindAsync(x => x.Email == userLoginDto.Email && x.Password == userLoginDto.Password);
                if (user == null)
                    return null;

                UserProfileDto userProfile = _mapper.Map<User, UserProfileDto>(user);

                return userProfile;
            }
        }


        public async Task<UserProfileDto> RegisterUserAsync(UserRegistrationDto userRegistrationDto)
        {
            using (_unitOfWork)
            {
                var userRepository = _unitOfWork.UserRepository;

                var user = userRepository.Find(x => x.Email == userRegistrationDto.Email);
                if (user != null)
                    return null;

                user = _mapper.Map<UserRegistrationDto, User>(userRegistrationDto);
                userRepository.Add(user);
                await _unitOfWork.SaveAsync();

                return await GetUserProfileInfo(_mapper.Map<UserRegistrationDto, UserLoginDto>(userRegistrationDto));
            }
        }
    }
}
