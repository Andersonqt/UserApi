using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;
using USER.WebApi.Domain.Repository;
using USER.WebApi.Domain.Services;
using USER.WebApi.DTOs.User;

namespace USER.WebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRespository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRespository = userRepository;
            _mapper = mapper;
        }

        public void Create(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            _userRespository.Create(user);
        }

        public User SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public UserInfoDTO UserInfo()
        {
            var user = _userRespository.UserInfo();
            return _mapper.Map<UserInfoDTO>(user);
        }
    }
}
