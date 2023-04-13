using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantBLL.BusinessLogic
{
    public class UserBs : IUserBs
    {
        private IUnitOfWork unitOfWork;

        UserBs(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetUsers()
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

    }
}
