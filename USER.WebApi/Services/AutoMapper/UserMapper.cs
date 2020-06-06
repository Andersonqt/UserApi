using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;
using USER.WebApi.DTOs.User;

namespace USER.WebApi.Services.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDTO, User>();
            CreateMap<PhoneDTO, Phone>();
            CreateMap<User, UserInfoDTO>()
                .ForMember(dest => dest.Created_At, opts => opts.MapFrom(src => src.Created_At.Value.ToString("dd/MM/yyyy HH:mm:ss")));
            CreateMap<User, UserSignInDTO>();
            CreateMap<Phone, UserPhoneInfoDTO>();
        }
    }
}
