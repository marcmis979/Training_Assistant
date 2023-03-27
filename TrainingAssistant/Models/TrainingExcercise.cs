using Asystent_Treningowy.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingAssistant.Models
{
    [Table("ExerciseMuscle")]
    public class TrainingExcercise
    {
        public int IdTraining { get; set; }
        public int IdExcercise { get; set; }
        [ForeignKey(nameof(IdTraining))]
        public Training Training { get; set; }
        [ForeignKey(nameof(IdExcercise))]
        public Excercise Excercise { get; set; }
    }
}
