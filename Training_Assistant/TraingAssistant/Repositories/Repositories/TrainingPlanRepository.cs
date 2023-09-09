using Microsoft.EntityFrameworkCore;
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
    public class TrainingPlanRepository : ITrainingPlanRepository
    {
        private TrainingAssistantContext context;

        public TrainingPlanRepository(TrainingAssistantContext context)
        {
            this.context = context;
        }

        public List<TrainingPlan> GetTrainingPlans()
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
            context.SaveChanges();
        }

        public void DeleteTrainingPlan(int id)
        {
            TrainingPlan trainingPlan = context.TrainingPlans.Find(id);
            context.TrainingPlans.Remove(trainingPlan);
            context.SaveChanges();
        }

        public void UpdateTrainingPlan(TrainingPlan updatedTrainingPlan)
        {
            var existingTrainingPlan = context.TrainingPlans.Find(updatedTrainingPlan.Id);

            if (existingTrainingPlan != null)
            {
                existingTrainingPlan.Name = updatedTrainingPlan.Name;

                context.SaveChanges();
            }
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
