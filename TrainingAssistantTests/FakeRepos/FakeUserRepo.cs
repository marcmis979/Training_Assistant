using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantTests.FakeRepos
{
    public class FakeUserRepo : IUserRepository
    {
        private List<User> _users = new List<User>();
        public IEnumerable<User> GetUsers()
        {
            return _users;
        }

        public User GetUserById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public void InsertUser(User training)
        {
            _users.Add(training);
        }

        public void DeleteUser(int id)
        {
            _users.Remove(_users.FirstOrDefault(x => x.Id == id));
        }

        public void UpdateUser(User training)
        {
            int index = training.Id;

            if (_users.Contains(training))
            {
                _users[index].Name = training.Name;
            }
            else
            {
                _users.Add(training);
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
