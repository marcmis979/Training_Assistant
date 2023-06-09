﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantBLL.BusinessLogic
{
    internal class TrainingPlanBs : ITrainingPlanBs
    {
        private IUnitOfWork unitOfWork;

        public TrainingPlanBs(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<TrainingPlan> GetTrainingPlans()
        {
            return unitOfWork.TrainingPlanRepository.GetTrainingPlans();
        }

        public TrainingPlan GetTrainingPlanById(int id)
        {
            return unitOfWork.TrainingPlanRepository.GetTrainingPlanById(id);
        }

        public void InsertTrainingPlan(TrainingPlan trainingPlan)
        {
            unitOfWork.TrainingPlanRepository.InsertTrainingPlan(trainingPlan);
        }

        public void UpdateTrainingPlan(TrainingPlan trainingPlan)
        {
            unitOfWork.TrainingPlanRepository.UpdateTrainingPlan(trainingPlan);
        }
        public void DeleteTrainingPlan(int id)
        {
            unitOfWork.TrainingPlanRepository.DeleteTrainingPlan(id);
        }

    }
}
