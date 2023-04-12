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
        public IEnumerable<Exercise> GetExercises();
        public Exercise GetExerciseById(int id);
        public void InsertExercise(Exercise exercise);
        public void UpdateExercise(Exercise exercise);
        public void DeleteExercise(int id);
    }
}
