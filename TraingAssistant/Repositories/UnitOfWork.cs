using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
         TrainingAssistantContext context;
        

        public UnitOfWork(TrainingAssistantContext trainingAssistantContext,IUserRepository userRepository, ITrainingPlanRepository trainingPlanRepository,ITrainingRepository trainingRepository ,IMusclePartRepository musclePartRepository,IExerciseRepository exerciseRepository)
        {
            this.context= trainingAssistantContext;
            this.UserRepository = userRepository;
            this.TrainingPlanRepository = trainingPlanRepository;
            this.TrainingRepository = trainingRepository;
            this.MusclePartRepository= musclePartRepository;
            this.ExerciseRepository = new ExerciseRepository(context);
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
            context.SaveChanges();
        }

     

        public void Dispose()
        {
            context.Dispose();
            
        }

    }
}
