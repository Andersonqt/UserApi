using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.DTOs.User
{
    public class UserTokenDTO
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}
