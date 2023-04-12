using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantBLL.BusinessLogic
{
    internal class TrainingBs : ITrainingBs
    {
        private TrainingRepository trainingRepository;

        public TrainingBs(TrainingRepository trainingRepository)
        {
            this.trainingRepository = trainingRepository;
        }

        public IEnumerable<Training> GetTrainings()
        {
            return trainingRepository.GetTrainings();
        }
        public Training GetTrainingById(int id)
        {
            return trainingRepository.GetTrainingById(id);
        }

        public void InsertTraining(Training training)
        {
            trainingRepository.InsertTraining(training);
        }

        public void UpdateTraining(Training training)
        {
            trainingRepository.UpdateTraining(training);
        }

        public void DeleteTraining(int id)
        {
            trainingRepository.DeleteTraining(id);
        }
    }
}
