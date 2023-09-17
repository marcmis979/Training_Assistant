using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories.Implementation
{
    public interface IUserRepository
    {
        List<User> GetUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void InsertUser(User user);
        void DeleteUser(int id);
        void UpdateUser(User user);
        public void AddTrainingPlanToUser(User updatedUser, int id);
        public void RemoveTrainingPlanFromUser(User updatedUser, int id);
        public void Save();
        public void Dispose();
    }
}
