using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.Services.AutoMapper
{
    public class AutoMapperProfile
    {
        public AutoMapperProfile()
        {
            new UserMapper();
        }
    }
}
