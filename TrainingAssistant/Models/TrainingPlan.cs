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
    public class TrainingPlan
    {
        [Key]
        public int IdPlan { get; set; }
        [Required, RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }
        public virtual User User { get; set; }
        [ForeignKey(nameof(Training))]
        public virtual ICollection<Training> Trainingies { get; set; }
    }
}
