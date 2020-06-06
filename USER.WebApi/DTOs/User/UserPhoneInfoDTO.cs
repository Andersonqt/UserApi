using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USER.WebApi.DTOs.User
{
    public class UserPhoneInfoDTO
    {
        public int Number { get; set; }
        public int Area_Code { get; set; }
        public string Country_Code { get; set; }
    }
}
