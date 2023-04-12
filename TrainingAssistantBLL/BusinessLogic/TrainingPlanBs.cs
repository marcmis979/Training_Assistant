using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantBLL.BusinessLogic
{
    internal class TrainingPlanBs : ITrainingPlanBs
    {
        private TrainingPlanRepository trainingPlanRepository;

        public TrainingPlanBs(TrainingPlanRepository trainingPlanRepository)
        {
            this.trainingPlanRepository = trainingPlanRepository;
        }
        public IEnumerable<TrainingPlan> GetTrainingPlans()
        {
            return trainingPlanRepository.GetTrainingPlans();
        }

        public TrainingPlan GetTrainingPlanById(int id)
        {
            return trainingPlanRepository.GetTrainingPlanById(id);
        }

        public void InsertTrainingPlan(TrainingPlan trainingPlan)
        {
            trainingPlanRepository.InsertTrainingPlan(trainingPlan);
        }

        public void UpdateTrainingPlan(TrainingPlan trainingPlan)
        {
            trainingPlanRepository.UpdateTrainingPlan(trainingPlan);
        }
        public void DeleteTrainingPlan(int id)
        {
            trainingPlanRepository.DeleteTrainingPlan(id);
        }

    }
}
