using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
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
                return new ResponseModel(false, errorCode: (int)ErrorCode.EAE, message: ErrorCode.EAE.GetEnumDescription());
            }
            var user = _mapper.Map<User>(userDto);
            return new ResponseModel(_userRespository.Create(user));
        }

        public ResponseModel SignIn(string email, string password)
        {
            var user = _userRespository.SignIn(email, password);
            if (user == null)
            {
                return new ResponseModel(false, errorCode: (int)ErrorCode.IEP, message: ErrorCode.EAE.GetEnumDescription());
            }

            var userMap = _mapper.Map<UserSignInDTO>(user);
            userMap.Token = GenerateToken();
            return new ResponseModel(true, userMap, message: "User successfully authenticated");
        }

        public ResponseModel UserInfo()
        {
            var user = _userRespository.UserInfo();
            return new ResponseModel(true, _mapper.Map<UserInfoDTO>(user));
        }

        private bool EmailAlreadyExists(string email)
        {
            return _userRespository.CheckEmailExists(email);
        }

        private string GenerateToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //Subject = new ClaimsIdentity(new Claim[]
                //{
                //    new Claim(ClaimTypes.Name, user.Username.ToString()),
                //    new Claim(ClaimTypes.Role, user.Role.ToString())
                //}),
                Expires = DateTime.UtcNow.AddHours(JwtSettings.LifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
