using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Data.Context;
using USER.WebApi.Domain.Models;
using USER.WebApi.Domain.Repository;

namespace USER.WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _context;
        public UserRepository(AppDataContext context)
        {
            _context = context;
        }
        public void Create(User entity)
        {
            _context.User.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public User SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User UserInfo()
        {
            var user = _context.User.Include(x => x.Phones).FirstOrDefault();
            return user;
        }
    }
}
