using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;

namespace USER.WebApi.Domain.Services
{
    public interface IUserService
    {
        void Create(User user);
        User UserInfo();
        User SignIn(string email, string password);
    }
}
