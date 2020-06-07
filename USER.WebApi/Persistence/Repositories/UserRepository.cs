using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER.WebApi.Domain.Models;
using USER.WebApi.Domain.Repositories;
using USER.WebApi.Persistence.Context;

namespace USER.WebApi.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDataContext _context;
        public UserRepository(AppDataContext context)
        {
            _context = context;
        }

        public bool CheckEmailExists(string email)
        {
            return _context.User.AsNoTracking().Where(x => x.Email.Trim().ToLower().Equals(email)).Any();
        }

        public bool Create(User entity)
        {
            entity.Created_At = DateTime.Now;
            _context.User.Add(entity);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public bool Delete(Guid id)
        {
            var user = GetById(id);
            _context.User.Remove(user);
            var result = _context.SaveChanges();
            return result > 0;
        }

        public User SignIn(string email, string password)
        {
            var user = _context.User.AsNoTracking().Where(x => x.Email.Equals(email) && x.Password.Equals(password)).FirstOrDefault();
            if (user != null)
            {
                UpdateLastLogin(user.Id);
            }
            return user;
        }

        private void UpdateLastLogin(Guid id)
        {
            var user = _context.User.Where(x => x.Id.Equals(id)).FirstOrDefault();
            user.Last_Login = DateTime.Now;
            _context.SaveChanges();
        }

        public User UserInfo(Guid id)
        {
            var user = _context.User.Include(x => x.Phones).AsNoTracking().Where(x => x.Id.Equals(id)).FirstOrDefault();
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.Include(x => x.Phones).AsNoTracking().ToList();
        }

        public User GetById(Guid id)
        {
            return _context.User.Include(x => x.Phones).AsNoTracking().Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
    }
}
