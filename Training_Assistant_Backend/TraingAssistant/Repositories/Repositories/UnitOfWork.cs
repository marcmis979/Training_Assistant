using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TraingAssistantDAL.Repositories.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {


        public UnitOfWork(IUserRepository userRepository, ITrainingPlanRepository trainingPlanRepository, ITrainingRepository trainingRepository, IMusclePartRepository musclePartRepository, IExerciseRepository exerciseRepository)
        {
            UserRepository = userRepository;
            TrainingPlanRepository = trainingPlanRepository;
            TrainingRepository = trainingRepository;
            MusclePartRepository = musclePartRepository;
            ExerciseRepository = exerciseRepository;
        }
        public IUserRepository UserRepository
        {
            get;
            private set;
        }

        public ITrainingPlanRepository TrainingPlanRepository
        {
            get;
            private set;
        }

        public ITrainingRepository TrainingRepository
        {
            get;
            private set;
        }

        public IMusclePartRepository MusclePartRepository
        {
            get;
            private set;
        }

        public IExerciseRepository ExerciseRepository
        {
            get;
            private set;
        }

        public void Save()
        {
            UserRepository.Save();
            TrainingRepository.Save();
            TrainingPlanRepository.Save();
            ExerciseRepository.Save();
            MusclePartRepository.Save();
        }

        public void Dispose()
        {
            UserRepository.Dispose();
            TrainingRepository.Dispose();
            TrainingPlanRepository.Dispose();
            ExerciseRepository.Dispose();
            MusclePartRepository.Dispose();
        }

    }
}
