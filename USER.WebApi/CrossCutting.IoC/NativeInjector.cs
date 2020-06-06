using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using USER.WebApi.Data.Context;
using USER.WebApi.Domain.Repository;
using USER.WebApi.Domain.Services;
using USER.WebApi.DTOs.User;
using USER.WebApi.DTOs.Validators;
using USER.WebApi.Repository;
using USER.WebApi.Services;
using USER.WebApi.Services.AutoMapper;

namespace USER.WebApi.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperProfile)));

            services.AddScoped<AppDataContext, AppDataContext>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            RegisterValidators(services);

            //services.AddTransient<IAlunoService, AlunoService>();
            //services.AddTransient<IAlunoRepository, AlunoRepository>();

            //services.AddTransient<ITreinoService, TreinoService>();
            //services.AddTransient<ITreinoRepository, TreinoRepository>();
        }

        private static void RegisterValidators(IServiceCollection services)
        {
            services.AddTransient<IValidator<UserDTO>, UserDtoValidator>();
        }
    }
}
