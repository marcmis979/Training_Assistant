using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantTests
{
    internal class TrainingRepoDummy : ITrainingRepository
    {
        public void DeleteTraining(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Training GetTrainingById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Training> GetTrainings()
        {
            throw new NotImplementedException();
        }

        public void InsertTraining(Training training)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateTraining(Training training)
        {
            throw new NotImplementedException();
        }

        List<Training> ITrainingRepository.GetTrainings()
        {
            throw new NotImplementedException();
        }
    }
}
