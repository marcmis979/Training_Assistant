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
        private IUnitOfWork unitOfWork;

        public ExerciseBs(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public IEnumerable<Exercise> GetExercises()
        {
            return unitOfWork.ExerciseRepository.GetExercises();
        }

        public Exercise GetExerciseById(int id)
        {
            return unitOfWork.ExerciseRepository.GetExerciseById(id);
        }

        public void InsertExercise(Exercise exercise)
        {
            unitOfWork.ExerciseRepository.InsertExercise(exercise);
        }

        public void UpdateExercise(Exercise exercise)
        {
            unitOfWork.ExerciseRepository.UpdateExercise(exercise);
        }
        public void DeleteExercise(int id)
        {
            unitOfWork.ExerciseRepository.DeleteExercise(id);
        }
    }
}
