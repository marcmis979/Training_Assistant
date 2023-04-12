using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantBLL.BusinessLogic
{
    internal class UserBs : IUserBs
    {
        private UserRepository userRepository;

        UserBs(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public IEnumerable<User> GetUsers()
        {
            return userRepository.GetUsers();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void InsertUser(User user)
        {
            userRepository.InsertUser(user);
        }

        public void UpdateUser(User user)
        {
            userRepository.UpdateUser(user);
        }
        public void DeleteUser(int id)
        {
            userRepository.DeleteUser(id);
        }

    }
}
