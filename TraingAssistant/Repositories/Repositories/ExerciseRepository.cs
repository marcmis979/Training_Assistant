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
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly TrainingAssistantContext _context;

        public ExerciseRepository(TrainingAssistantContext context)
        {
            _context = context;
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return _context.Exercises.ToList();
        }

        public Exercise GetExerciseById(int id)
        {
            var exercise = _context.Exercises.Find(id);
            return exercise;
        }

        public void InsertExercise(Exercise exercise)
        {

            _context.Exercises.Add(exercise);
            _context.SaveChanges();
        }

        public void DeleteExercise(int id)
        {
            Exercise exercise = _context.Exercises.Find(id);
            _context.Exercises.Remove(exercise);
        }

        public void UpdateExercise(Exercise updatedExercise)
        {
            var existingExercise = _context.Exercises.Find(updatedExercise.Id);

            if (existingExercise != null)
            {
                existingExercise.Name = updatedExercise.Name;

                _context.SaveChanges();
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
