using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAssistant.Models;

namespace Asystent_Treningowy.Models
{
    [Table("Training")]
    public class Training
    {
        [Key]
        public int IdTraining { get; set; }
        [Required, RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }
        [Required,RegularExpression("^[1-9]\\d*$")]
        public int Days { get; set; }
        public List<TrainingExercise> TrainingExercise { get; set; }
        
        [ForeignKey("TrainingPlan")]
        public int IdTrainingPlan { get; set; }
        public virtual TrainingPlan Tp { get; set; }
    }
}
