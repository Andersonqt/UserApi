using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;
using USER.WebApi.Domain.Repository;
using USER.WebApi.Domain.Services;

namespace USER.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRespository;
        public UserService(IUserRepository userRepository)
        {
            _userRespository = userRepository;
        }

        public void Create(User user)
        {
            _userRespository.Create(user);
        }

        public User SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User UserInfo()
        {
            return _userRespository.UserInfo();
        }
    }
}
