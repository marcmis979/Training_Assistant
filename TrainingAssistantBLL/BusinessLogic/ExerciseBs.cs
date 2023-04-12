using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantBLL.BusinessLogic
{
    public class ExerciseBs : IExerciseBs
    {
        private ExerciseRepository exerciseRepository;

        public ExerciseBs(ExerciseRepository exerciseRepository)
        {
            this.exerciseRepository = exerciseRepository;
        }
        
        public IEnumerable<Exercise> GetExercises()
        {
            return exerciseRepository.GetExercises();
        }

        public Exercise GetExerciseById(int id)
        {
            return exerciseRepository.GetExerciseById(id);
        }

        public void InsertExercise(Exercise exercise)
        {
            exerciseRepository.InsertExercise(exercise);
        }

        public void UpdateExercise(Exercise exercise)
        {
            exerciseRepository.UpdateExercise(exercise);
        }
        public void DeleteExercise(int id)
        {
            exerciseRepository.DeleteExercise(id);
        }
    }
}
