using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TraingAssistantDAL.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TrainingAssistantContext _context;

        public UserRepository(TrainingAssistantContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public void InsertUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            User user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User updatedUser)
        {
            var existingUser = _context.Users.Find(updatedUser.Id);

            if (existingUser != null)
            {
                existingUser.Name = updatedUser.Name;
                existingUser.Surname = updatedUser.Surname;
                existingUser.Sex = updatedUser.Sex;
                existingUser.Age = updatedUser.Age;
                existingUser.Height = updatedUser.Height;
                existingUser.Weight = updatedUser.Weight;
                existingUser.TargetWeight = updatedUser.TargetWeight;
                existingUser.Tempo = updatedUser.Tempo;
                existingUser.Password = updatedUser.Password;
                existingUser.Email = updatedUser.Email;

                _context.SaveChanges();
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
