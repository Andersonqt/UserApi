using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using USER.WebApi.Domain.Repositories;
using USER.WebApi.Domain.Services;
using USER.WebApi.Persistence.Context;
using USER.WebApi.Persistence.Repositories;
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
        }
    }
}
