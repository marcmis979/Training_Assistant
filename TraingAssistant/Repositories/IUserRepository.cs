using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUserById(int id);
        void InsertUser(User user);
        void DeleteUser(int id);
        void UpdateStudent(User user);
        void Save();
    }
}
