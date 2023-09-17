using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TrainingAssistantBLL.BusinessLogic
{
    public interface IExerciseBs
    {
        public List<Exercise> GetExercises();
        public Exercise GetExerciseById(int id);
        public void InsertExercise(Exercise exercise);
        public void UpdateExercise(Exercise exercise);
        public void DeleteExercise(int id);
        public double burnedPerHour(int id);
        public void AddMusclePartToExercise(Exercise updatedExercise, int musclePartId);
        public void RemoveMusclePartFromExercise(Exercise updatedExercise, int musclePartId);
    }
}
