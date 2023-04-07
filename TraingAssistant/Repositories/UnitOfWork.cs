using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private TrainingAssistantContext context = new TrainingAssistantContext();
        private GenericRepository<User> userRepository;
        private GenericRepository<TrainingPlan> trainingPlanRepository;
        private GenericRepository<Training> trainingRepository;
        private GenericRepository<MusclePart> musclePartRepository;
        private GenericRepository<Exercise> exerciseRepository;


        public GenericRepository<User> UserRepository
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        public GenericRepository<TrainingPlan> TrainingPlanRepository
        {
            get
            {

                if (this.trainingPlanRepository == null)
                {
                    this.trainingPlanRepository = new GenericRepository<TrainingPlan>(context);
                }
                return trainingPlanRepository;
            }
        }

        public GenericRepository<Training> TrainingRepository
        {
            get
            {

                if (this.trainingRepository == null)
                {
                    this.trainingRepository = new GenericRepository<Training>(context);
                }
                return trainingRepository;
            }
        }

        public GenericRepository<MusclePart> MusclePartRepository
        {
            get
            {

                if (this.musclePartRepository == null)
                {
                    this.musclePartRepository = new GenericRepository<MusclePart>(context);
                }
                return musclePartRepository;
            }
        }

        public GenericRepository<Exercise> ExerciseRepository
        {
            get
            {

                if (this.exerciseRepository == null)
                {
                    this.exerciseRepository = new GenericRepository<Exercise>(context);
                }
                return exerciseRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
