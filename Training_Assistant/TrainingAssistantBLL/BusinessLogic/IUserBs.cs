using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TrainingAssistantBLL.BusinessLogic
{
    public interface IUserBs
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public User GetUserByEmail(string email);
        public void InsertUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int id);
        public double getUserBMI(int id);
        public void AddTrainingPlanToUser(User updatedUser, int trainingPlanId);
        public void RemoveTrainingPlanFromUser(User updatedUser, int trainingPlanId);
    }
}
