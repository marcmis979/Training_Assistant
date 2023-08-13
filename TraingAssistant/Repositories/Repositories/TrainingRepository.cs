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
            return context.Trainings
                   .Include(t => t.TrainingExercises)
                       .ThenInclude(te => te.Exercise)
                   .FirstOrDefault(t => t.Id == id);
        }

        public void InsertTraining(Training training)
        {
            context.Trainings.Add(training);
        }

        public void DeleteTraining(int id)
        {
            Training training = context.Trainings.Find(id);
            context.Trainings.Remove(training);
        }

        public void UpdateTraining(Training training)
        {
            context.Entry(training).State = EntityState.Modified;
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
