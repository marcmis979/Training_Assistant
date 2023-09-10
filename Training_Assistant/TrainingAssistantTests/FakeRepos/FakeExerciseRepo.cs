using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantTests.FakeRepos
{
    public class FakeExerciseRepo : IExerciseRepository
    {
        private List<Exercise> _exercises = new List<Exercise>();
        public IEnumerable<Exercise> GetExercises()
        {
            return _exercises;
        }

        public Exercise GetExerciseById(int id)
        {
            return _exercises.FirstOrDefault(x => x.Id == id);
        }

        public void InsertExercise(Exercise training)
        {
            _exercises.Add(training);
        }

        public void DeleteExercise(int id)
        {
            _exercises.Remove(_exercises.FirstOrDefault(x => x.Id == id));
        }

        public void UpdateExercise(Exercise exercise)
        {
            int index = exercise.Id;

            if (_exercises.Contains(exercise))
            {
                _exercises[index].Name = exercise.Name;
            }
            else
            {
                _exercises.Add(exercise);
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

        List<Exercise> IExerciseRepository.GetExercises()
        {
            throw new NotImplementedException();
        }
    }
}
