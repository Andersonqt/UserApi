using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;

namespace USER.WebApi.Domain.Repositories
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User UserInfo(Guid id);
        User SignIn(string email, string password);
        bool CheckEmailExists(string email);
    }
}
