using Asystent_Treningowy.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrainingAssistant.Models
{
    [Table("ExerciseMuscle")]
    public class ExerciseMuscle
    {
        [ForeignKey("Excercise")]
        public int IdExercise { get; set; }
        [ForeignKey("MusclePart")]
        public int IdMusclePart { get; set; }
        public Excercise excercise { get; set; }
        public MusclePart musclePart { get; set; }
    }

}
