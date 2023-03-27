using Asystent_Treningowy.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrainingAssistant.Models
{
    [Table("ExerciseMuscle")]
    public class ExerciseMuscle
    {

        public int IdExercise { get; set; }
        public int IdMusclePart { get; set; }
        [ForeignKey(nameof(IdExercise))]
        public Excercise Excercise { get; set; }
        [ForeignKey(nameof(IdMusclePart))]
        public MusclePart MusclePart { get; set; }
    }

}
