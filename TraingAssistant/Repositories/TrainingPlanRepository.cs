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
    public class TrainingPlanRepository : ITrainingPlanRepository, IDisposable
    {
        private TrainingAssistantContext context;

        public TrainingPlanRepository(TrainingAssistantContext context)
        {
            this.context = context;
        }

        public IEnumerable<TrainingPlan> GetTrainingPlans()
        {
            return context.TrainingPlans.ToList();
        }

        public TrainingPlan GetTrainingPlanById(int id)
        {
            return context.TrainingPlans.Find(id);
        }

        public void InsertTrainingPlan(TrainingPlan trainingPlan)
        {
            context.TrainingPlans.Add(trainingPlan);
        }

        public void DeleteTrainingPlan(int id)
        {
            TrainingPlan trainingPlan = context.TrainingPlans.Find(id);
            context.TrainingPlans.Remove(trainingPlan);
        }

        public void UpdateTrainingPlan(TrainingPlan trainingPlan)
        {
            context.Entry(trainingPlan).State = EntityState.Modified;
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
