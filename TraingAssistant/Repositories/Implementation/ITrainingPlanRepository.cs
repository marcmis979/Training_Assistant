﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories.Implementation
{
    public interface ITrainingPlanRepository
    {
        IEnumerable<TrainingPlan> GetTrainingPlans();
        TrainingPlan GetTrainingPlanById(int id);
        void InsertTrainingPlan(TrainingPlan trainingPlan);
        void DeleteTrainingPlan(int id);
        void UpdateTrainingPlan(TrainingPlan trainingPlan);
        public void Save();
        public void Dispose();
    }
}
