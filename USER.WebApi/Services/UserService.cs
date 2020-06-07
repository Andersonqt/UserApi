using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
            return new ResponseModel(true, _userRespository.Create(user), message: "User successfully registered ");
        }

        public ResponseModel SignIn(string email, string password)
        {
            var user = _userRespository.SignIn(email, password);
            if (user == null)
            {
                return new ResponseModel(false, errorCode: (int)ErrorCode.IEP, message: ErrorCode.IEP.GetEnumDescription());
            }

            var userMap = _mapper.Map<UserSignInDTO>(user);
            var token = GenerateToken(user.Id);
            userMap.Token = token.Token;
            userMap.TokenExpiration = token.Expiration;
            return new ResponseModel(true, userMap, "User successfully authenticated");
        }

        public ResponseModel UserInfo(Guid id)
        {
            var user = _userRespository.UserInfo(id);
            var userMap = _mapper.Map<UserInfoDTO>(user);
            return new ResponseModel(true, userMap);
        }
        public ResponseModel AllUsers()
        {
            var users = _mapper.Map<IEnumerable<UserInfoDTO>>(_userRespository.GetAll());
            return new ResponseModel(true, users);
        }

        public ResponseModel DeleteUser(Guid id)
        {
            var user = _userRespository.GetById(id);
            if (user == null) return new ResponseModel(false, message: "User doesn't exist");
            return new ResponseModel(true, _userRespository.Delete(id), message: "Deleted user");
        }

        private bool EmailAlreadyExists(string email)
        {
            return _userRespository.CheckEmailExists(email);
        }

        private UserTokenDTO GenerateToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(JwtSettings.Secret);
            var expires = DateTime.UtcNow.AddHours(JwtSettings.LifeTime);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userId.ToString())
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new UserTokenDTO
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = expires.ToString("dd/MM/yyyy HH:mm:ss")
            };
        }

        public ResponseModel GetById(Guid id)
        {
            var userMap = _mapper.Map<UserInfoDTO>(_userRespository.GetById(id));
            return new ResponseModel(true, userMap);
        }
    }
}
