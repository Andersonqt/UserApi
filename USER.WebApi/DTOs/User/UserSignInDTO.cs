using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.DTOs.User
{
    public class UserSignInDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string TokenExpiration { get; set; }
    }
}
