using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asystent_Treningowy.Models
{
    [Table("TrainingPlan")]
    internal class TrainingPlan
    {
        [Key]
        public int IdPlan { get; set; }
        [Required, RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }
        [ForeignKey(nameof(Training))]
        public Training[] Trainings { get; set; }

    }
}
