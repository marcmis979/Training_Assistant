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
        public IEnumerable<User> GetUsers();
        public User GetUserById(int id);
        public void InsertUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int id);
    }
}
