using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories
{
    public class ExerciseRepository : IExerciseRepository, IDisposable
    {
        private TrainingAssistantContext context;

        public ExerciseRepository(TrainingAssistantContext context)
        {
            this.context = context;
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return context.Exercises.ToList();
        }

        public Exercise GetExerciseById(int id)
        {
            return context.Exercises.Find(id);
        }

        public void InsertExercise(Exercise exercise)
        {
            context.Exercises.Add(exercise);
        }

        public void DeleteExercise(int id)
        {
            Exercise exercise = context.Exercises.Find(id);
            context.Exercises.Remove(exercise);
        }

        public void UpdateExercise(Exercise exercise)
        {
            context.Entry(exercise).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
