using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories
{
    public class TrainingRepository : ITrainingRepository, IDisposable
    {
        private TrainingAssistantContext context;

        public TrainingRepository(TrainingAssistantContext context)
        {
            this.context = context;
        }

        public IEnumerable<Training> GetTrainings()
        {
            return context.Trainings.ToList();
        }

        public Training GetTrainingById(int id)
        {
            return context.Trainings.Find(id);
        }

        public void InsertTraining(Training training)
        {
            context.Trainings.Add(training);
        }

        public void DeleteTraining(int id)
        {
            Training training = context.Trainings.Find(id);
            context.Trainings.Remove(training);
        }

        public void UpdateTraining(Training training)
        {
            context.Entry(training).State = EntityState.Modified;
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
