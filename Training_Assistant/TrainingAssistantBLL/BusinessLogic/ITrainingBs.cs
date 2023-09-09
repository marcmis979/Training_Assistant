using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TrainingAssistantBLL.BusinessLogic
{
    public interface ITrainingBs
    {
        public List<Training> GetTrainings();
        public Training GetTrainingById(int id);
        public void InsertTraining(Training training);
        public void UpdateTraining(Training training);
        public void DeleteTraining(int id);
        public double summaryCalories(int id);
    }
}
