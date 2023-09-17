using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TrainingAssistantBLL.BusinessLogic
{
    public interface ITrainingPlanBs
    {
        public List<TrainingPlan> GetTrainingPlans();
        public TrainingPlan GetTrainingPlanById(int id);
        public void InsertTrainingPlan(TrainingPlan trainingPlan);
        public void UpdateTrainingPlan(TrainingPlan trainingPlan);
        public void DeleteTrainingPlan(int id);
        public void AddTrainingToTrainingPlan(TrainingPlan updatedTrainingPlan, int trainingId);
    }
}
