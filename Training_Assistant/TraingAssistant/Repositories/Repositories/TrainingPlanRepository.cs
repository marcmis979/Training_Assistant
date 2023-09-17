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
            var trainingPlan = context.TrainingPlans
                .Include(t => t.Trainings)
                .ToList();
            return trainingPlan;
        }

        public TrainingPlan GetTrainingPlanById(int id)
        {
            var trainingPlan = context.TrainingPlans
                .Include(t => t.Trainings)
                .FirstOrDefault(t => t.Id == id);
            return trainingPlan;
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

        public void AddTrainingToTrainingPlan(TrainingPlan updatedTrainingPlan, int id)
        {
            var existingTrainingPlan = context.TrainingPlans.Find(updatedTrainingPlan.Id);
            var relatedTraining = context.Trainings.Find(id);

            if (existingTrainingPlan != null)
            {
                existingTrainingPlan.Trainings.Add(relatedTraining);
                context.SaveChanges();
            }
        }

        public void RemoveTrainingFromTrainingPlan(TrainingPlan updatedTrainingPlan, int id)
        {
            var existingTrainingPlan = context.TrainingPlans.Find(updatedTrainingPlan.Id);
            var relatedTraining = context.Trainings.Find(id);

            if (existingTrainingPlan != null)
            {
                existingTrainingPlan.Trainings.Remove(relatedTraining);
                context.SaveChanges();
            }
        }
    }
}
