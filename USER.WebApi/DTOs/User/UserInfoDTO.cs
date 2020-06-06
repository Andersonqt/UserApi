using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.DTOs.User
{
    public class UserInfoDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Created_At { get; set; }
        public string Last_Login { get; set; }
        public IEnumerable<UserPhoneInfoDTO> Phones { get; set; }
    }
}
