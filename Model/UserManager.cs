using System;
using System.Collections.Generic;
using System.Linq;
using hospitalmanagement.Data;
using hospitalmanagement.Model;
using hospitalmanagement.Entities;

namespace hospitalmanagement.Model{
    public class UserManager : IDataRepository<User>
    {
        private readonly dbContext _dbContext;
        public UserManager(dbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(User entity)
        {
            _dbContext.user.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _dbContext.user.Remove(entity);
            _dbContext.SaveChanges();
        }

        public User GetUser(int id)
        {
            return _dbContext.user.SingleOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return _dbContext.user.ToList();
        }

        public void Update(User user, User entity)
        {
            user.firstName = entity.firstName;
            user.lastName = entity.lastName;
            user.Password = entity.Password;
            user.Email = entity.Email;
            user.isDeleted = entity.isDeleted;
            user.hospitalId = entity.hospitalId;

            _dbContext.SaveChanges();
        }
    }
}