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

        public List<Training> GetTrainings()
        {
            var training = context.Trainings
                .Include(e => e.Exercises)
                .ToList();
            return training;
        }

        public Training GetTrainingById(int id)
        {
            var training = context.Trainings
                .Include(e => e.Exercises)
                .FirstOrDefault(e => e.Id == id);
            return training;
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

        public void AddExerciseToTraining(Training updatedTraining, int exerciseId)
        {
            var existingTraining = context.Trainings.Find(updatedTraining.Id);
            var relatedExercise = context.Exercises.Find(exerciseId);

            if (existingTraining != null)
            {
                existingTraining.Exercises.Add(relatedExercise);
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
