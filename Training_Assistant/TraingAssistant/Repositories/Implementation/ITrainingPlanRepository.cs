using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories.Implementation
{
    public interface ITrainingPlanRepository
    {
        List<TrainingPlan> GetTrainingPlans();
        TrainingPlan GetTrainingPlanById(int id);
        void InsertTrainingPlan(TrainingPlan trainingPlan);
        void DeleteTrainingPlan(int id);
        void UpdateTrainingPlan(TrainingPlan trainingPlan);
        public void AddTrainingToTrainingPlan(TrainingPlan updatedTrainingPlan, int id);
        public void RemoveTrainingFromTrainingPlan(TrainingPlan updatedTrainingPlan, int id);
        public void Save();
        public void Dispose();
    }
}
