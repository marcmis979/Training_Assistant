using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantTests
{
    internal class ExerciseRepoDummy : IExerciseRepository
    {
        public void DeleteExercise(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Exercise GetExerciseById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Exercise> GetExercises()
        {
            throw new NotImplementedException();
        }

        public void InsertExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateExercise(Exercise exercise)
        {
            throw new NotImplementedException();
        }

        List<Exercise> IExerciseRepository.GetExercises()
        {
            throw new NotImplementedException();
        }
    }
}
