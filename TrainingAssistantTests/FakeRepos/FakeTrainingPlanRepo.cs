using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantTests.FakeRepos
{
    public class FakeTrainingPlanRepo : ITrainingPlanRepository
    {
        private List<TrainingPlan> _trainingPlans = new List<TrainingPlan>();
        public IEnumerable<TrainingPlan> GetTrainingPlans()
        {
            return _trainingPlans;
        }

        public TrainingPlan GetTrainingPlanById(int id)
        {
            return _trainingPlans.FirstOrDefault(x => x.Id == id);
        }

        public void InsertTrainingPlan(TrainingPlan trainingPlan)
        {
            _trainingPlans.Add(trainingPlan);
        }

        public void DeleteTrainingPlan(int id)
        {
            _trainingPlans.Remove(_trainingPlans.FirstOrDefault(x => x.Id == id));
        }

        public void UpdateTrainingPlan(TrainingPlan training)
        {
            int index = training.Id;

            if (_trainingPlans.Contains(training))
            {
                _trainingPlans[index].Name = training.Name;
            }
            else
            {
                _trainingPlans.Add(training);
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
