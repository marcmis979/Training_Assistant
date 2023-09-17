using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantTests.ControllersTests
{
    internal class TrainingBLLMock : ITrainingBs
    {
        public void AddExerciseToTraining(Training updatedTraining, int exerciseId)
        {
            throw new NotImplementedException();
        }

        public void DeleteTraining(int id)
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

        public double summaryCalories(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateTraining(Training training)
        {
            throw new NotImplementedException();
        }

        List<Training> ITrainingBs.GetTrainings()
        {
            throw new NotImplementedException();
        }
    }
}
