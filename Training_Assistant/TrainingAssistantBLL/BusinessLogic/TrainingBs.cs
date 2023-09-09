using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantBLL.BusinessLogic
{
    public class TrainingBs : ITrainingBs
    {
        private IUnitOfWork unitOfWork;

        public TrainingBs(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Training> GetTrainings()
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
        public double summaryCalories(int id)
        {
            double sum = 0.0;

            Training training = unitOfWork.TrainingRepository.GetTrainingById(id);

            if (training != null)
            {
                foreach (TrainingExercise trainingExercise in training.TrainingExercises)
                {
                    sum += trainingExercise.Exercise.BurnedKcal;
                }
            }

            return sum;
        }


    }
}
