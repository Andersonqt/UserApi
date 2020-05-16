using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Data.Context;
using USER.WebApi.Domain.Repository;
using USER.WebApi.Domain.Services;
using USER.WebApi.Repository;
using USER.WebApi.Services;

namespace USER.WebApi.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetAssembly(typeof(DTOAutoMapper)));

            services.AddScoped<AppDataContext, AppDataContext>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();

            //services.AddTransient<IAlunoService, AlunoService>();
            //services.AddTransient<IAlunoRepository, AlunoRepository>();

            //services.AddTransient<ITreinoService, TreinoService>();
            //services.AddTransient<ITreinoRepository, TreinoRepository>();
        }
    }
}
