using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories.Implementation
{
    public interface IUnitOfWork : IDisposable
    {
        public IUserRepository UserRepository { get; }
        public ITrainingPlanRepository TrainingPlanRepository { get; }
        public ITrainingRepository TrainingRepository { get; }
        public IMusclePartRepository MusclePartRepository { get; }
        public IExerciseRepository ExerciseRepository { get; }
        public void Save();

    }
}
