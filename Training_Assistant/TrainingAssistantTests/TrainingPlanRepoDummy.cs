using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantTests
{
    internal class TrainingPlanRepoDummy : ITrainingPlanRepository
    {
        public void AddTrainingToTrainingPlan(TrainingPlan updatedTrainingPlan, int id)
        {
            throw new NotImplementedException();
        }

        public List<TrainingPlan> GetTrainingPlans()
        {
            throw new NotImplementedException();
        }

        public void RemoveTrainingFromTrainingPlan(TrainingPlan updatedTrainingPlan, int id)
        {
            throw new NotImplementedException();
        }

        void ITrainingPlanRepository.DeleteTrainingPlan(int id)
        {
            throw new NotImplementedException();
        }

        void ITrainingPlanRepository.Dispose()
        {
            throw new NotImplementedException();
        }

        TrainingPlan ITrainingPlanRepository.GetTrainingPlanById(int id)
        {
            throw new NotImplementedException();
        }

        List<TrainingPlan> ITrainingPlanRepository.GetTrainingPlans()
        {
            throw new NotImplementedException();
        }

        void ITrainingPlanRepository.InsertTrainingPlan(TrainingPlan trainingPlan)
        {
            throw new NotImplementedException();
        }

        void ITrainingPlanRepository.Save()
        {
            throw new NotImplementedException();
        }

        void ITrainingPlanRepository.UpdateTrainingPlan(TrainingPlan trainingPlan)
        {
            throw new NotImplementedException();
        }
    }
}
