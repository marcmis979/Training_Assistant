﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories.Implementation
{
    public interface IExerciseRepository
    {
        IEnumerable<Exercise> GetExercises();
        Exercise GetExerciseById(int id);
        void InsertExercise(Exercise exercise);
        void DeleteExercise(int id);
        void UpdateExercise(Exercise exercise);
        public void Save();
        public void Dispose();
    }
}
