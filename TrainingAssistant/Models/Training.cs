using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asystent_Treningowy.Models
{
    [Table("Training")]
    internal class Training
    {
        [Key]
        public int IdTraining { get; set; }
        [ForeignKey(nameof(Excercise))]
        Excercise[] excercises { get; set; }
        [Required, RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }
        [Required,RegularExpression("^[1-9]\\d*$")]
        public int Days { get; set; }
    }
}
