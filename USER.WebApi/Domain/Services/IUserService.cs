using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;
using USER.WebApi.DTOs.User;

namespace USER.WebApi.Domain.Services
{
    public interface IUserService
    {
        void Create(UserDTO user);
        UserInfoDTO UserInfo();
        User SignIn(string email, string password);
    }
}
