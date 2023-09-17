using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantBLL.BusinessLogic
{
    public class UserBs : IUserBs
    {
        private IUnitOfWork unitOfWork;

        public UserBs(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<User> GetUsers()
        {
            return unitOfWork.UserRepository.GetUsers();
        }

        public User GetUserById(int id)
        {
            return unitOfWork.UserRepository.GetUserById(id);
        }

        public void InsertUser(User user)
        {
            unitOfWork.UserRepository.InsertUser(user);
        }

        public void UpdateUser(User user)
        {
            unitOfWork.UserRepository.UpdateUser(user);
        }
        public void DeleteUser(int id)
        {
            unitOfWork.UserRepository.DeleteUser(id);
        }
        public double getUserBMI(int id)
        {
            double heightInMeters = GetUserById(id).Height / 100.0;
            return GetUserById(id).Weight / (heightInMeters * heightInMeters);
        }

        public User GetUserByEmail(string email)
        {
            return unitOfWork.UserRepository.GetUserByEmail(email);
        }

        public void AddTrainingPlanToUser(User updatedUser, int trainingPlanId)
        {
            unitOfWork.UserRepository.AddTrainingPlanToUser(updatedUser, trainingPlanId);
        }
    }
}
