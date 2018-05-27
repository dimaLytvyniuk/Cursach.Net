using Labange.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Labange.BLL.Interfaces
{
    public interface IAccountService
    {
        Task<UserProfileDto> RegisterUserAsync(UserRegistrationDto userRegistrationDto);
        Task<UserProfileDto> GetUserProfileInfo(UserLoginDto userLoginDto);
    }
}
