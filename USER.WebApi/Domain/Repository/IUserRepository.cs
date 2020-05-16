using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;

namespace USER.WebApi.Domain.Repository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User UserInfo();
        User SignIn(string email, string password);
    }
}
