﻿using Microsoft.EntityFrameworkCore;
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
            throw new NotImplementedException();
        }

        public User SignIn(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User UserInfo()
        {
            var users = _context.User.Include(x => x.Phones).ToList();
            var user = _context.User.Include(x => x.Phones).FirstOrDefault();
            return user;
        }
    }
}