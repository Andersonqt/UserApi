using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;
using USER.WebApi.Domain.Repositories;
using USER.WebApi.Domain.Services;
using USER.WebApi.DTOs;
using USER.WebApi.DTOs.User;
using static USER.WebApi.Domain.Enums;

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

        public ResponseModel Create(UserDTO userDto)
        {
            if (EmailAlreadyExists(userDto.Email))
            {
                return new ResponseModel(errorCode: (int)ErrorCode.EAE, message: ErrorCode.EAE.GetEnumDescription());
            }
            var user = _mapper.Map<User>(userDto);
            return new ResponseModel(_userRespository.Create(user));
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

        private bool EmailAlreadyExists(string email)
        {
            return _userRespository.CheckEmailExists(email);
        }
    }
}
