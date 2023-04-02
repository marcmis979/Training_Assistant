using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum TypeEnum
{
    aerobic,
    strength,
    flexibility,
    mobility,
    balance
};
namespace TraingAssistantDAL.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BurnedKcal { get; set; }
        public int Time { get; set; }
        public TypeEnum Type { get; set; }
        public List<ExerciseMusclePart> ExercisesMuscleParts { get; set; }
        public List<TrainingExercise> TrainingExercises { get; set; }
    }
}
