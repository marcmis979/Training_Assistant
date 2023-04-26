using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantTests.FakeRepos
{
    public class FakeTrainingRepo :ITrainingRepository
    {
        private List<Training> _trainings = new List<Training>();
        public IEnumerable<Training> GetTrainings()
        {
            return _trainings;
        }

        public Training? GetTrainingById(int id)
        {
            return _trainings.FirstOrDefault(x => x.Id == id);
        }

        public void InsertTraining(Training training)
        {
            _trainings.Add(training);
        }

        public void DeleteTraining(int id)
        {
            _trainings.Remove(_trainings.FirstOrDefault(x => x.Id == id));
        }

        public void UpdateTraining(Training training)
        {
            int index = training.Id;

            if (_trainings.Contains(training))
            {
                _trainings[index].Name = training.Name;
                _trainings[index].Days = training.Days;
            }
            else
            {
                _trainings.Add(training);
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
