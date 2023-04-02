using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraingAssistantDAL.Models
{
    public class TrainingExercise
    {
        public int TrainingId;
        public int ExerciseId;
        public Training Training { get; set; }
        public Exercise Exercise { get; set; }
    }
}
