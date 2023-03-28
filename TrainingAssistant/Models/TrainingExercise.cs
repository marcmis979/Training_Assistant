using Asystent_Treningowy.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainingAssistant.Models
{
    [Table("TrainingExercise")]
    public class TrainingExercise
    {
        [ForeignKey("Training")]
        public int IdTrainings { get; set; }
        [ForeignKey("Excercise")]
        public int IdExcercises { get; set; }
        
        public Training training { get; set; }
        
        public Excercise exercise { get; set; }
    }
}
