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

        public List<Exercise> GetExercises()
        {
            return _context.Exercises
                .Include(e => e.MuscleParts)
                .ToList();
        }

        public Exercise GetExerciseById(int id)
        {
            var exercise = _context.Exercises
                .Include(e => e.MuscleParts)
                .FirstOrDefault(e => e.Id == id);
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
            _context.SaveChanges();
        }

        public void UpdateExercise(Exercise updatedExercise)
        {
            var existingExercise = _context.Exercises.Find(updatedExercise.Id);

            if (existingExercise != null)
            {
                existingExercise.Name = updatedExercise.Name;
                existingExercise.BurnedKcal = updatedExercise.BurnedKcal;
                existingExercise.Time = updatedExercise.Time;
                existingExercise.Type = updatedExercise.Type;

                _context.SaveChanges();
            }
        }
        public void AddMusclePartToExercise(Exercise updatedExercise, int musclePartId)
        {
            var existingExercise = _context.Exercises.Find(updatedExercise.Id);
            var relatedMusclePart = _context.MuscleParts.Find(musclePartId);

            if (existingExercise != null)
            {
                existingExercise.MuscleParts.Add(relatedMusclePart);
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
