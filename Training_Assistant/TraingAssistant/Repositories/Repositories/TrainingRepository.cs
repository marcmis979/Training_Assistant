using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TraingAssistantDAL.Repositories.Repositories
{
    public class TrainingRepository : ITrainingRepository
    {
        private TrainingAssistantContext context;

        public TrainingRepository(TrainingAssistantContext context)
        {
            this.context = context;
        }

        public IEnumerable<Training> GetTrainings()
        {
            return context.Trainings.ToList();
        }

        public Training GetTrainingById(int id)
        {
            return context.Trainings.Find(id);
        }

        public void InsertTraining(Training training)
        {
            context.Trainings.Add(training);
            context.SaveChanges();
        }

        public void DeleteTraining(int id)
        {
            Training training = context.Trainings.Find(id);
            context.Trainings.Remove(training);
            context.SaveChanges();
        }

        public void UpdateTraining(Training updatedTraining)
        {
            var existingTraining = context.Trainings.Find(updatedTraining.Id);

            if (existingTraining != null)
            {
                existingTraining.Name = updatedTraining.Name;
                existingTraining.Days = updatedTraining.Days;

                context.SaveChanges();
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
