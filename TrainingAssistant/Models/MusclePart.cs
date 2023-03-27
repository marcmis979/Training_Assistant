using Microsoft.EntityFrameworkCore;
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
    [Table("MusclePart")]
    public class MusclePart
    {
        [Key]
        public int IdPart { get; set; }
        [Required, RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }
        public List<ExerciseMuscle> ExerciseMuscle { get; set; }
    }
}
