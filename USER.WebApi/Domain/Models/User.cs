using System;
using System.Collections.Generic;

namespace USER.WebApi.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Created_At { get; set; }
        public DateTime? Last_Login { get; set; }
        public virtual IEnumerable<Phone> Phones { get; set; }
    }
}