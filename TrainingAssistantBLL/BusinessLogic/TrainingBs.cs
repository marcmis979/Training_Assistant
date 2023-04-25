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
        private IUnitOfWork unitOfWork;

        public TrainingBs(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Training> GetTrainings()
        {
            return unitOfWork.TrainingRepository.GetTrainings();
        }
        public Training GetTrainingById(int id)
        {
            return unitOfWork.TrainingRepository.GetTrainingById(id);
        }

        public void InsertTraining(Training training)
        {
            unitOfWork.TrainingRepository.InsertTraining(training);
        }

        public void UpdateTraining(Training training)
        {
            unitOfWork.TrainingRepository.UpdateTraining(training);
        }

        public void DeleteTraining(int id)
        {
            unitOfWork.TrainingRepository.DeleteTraining(id);
        }
        public double summaryCallories(int id)
        {
            double sum = 0.0;
            Training training = GetTrainingById(id);
            foreach (TrainingExercise trainingExercise in training.TrainingExercises)
            {
                sum += trainingExercise.Exercise.BurnedKcal;
            }
            return sum;
        }
    }
}
