using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TrainingAssistant.Models;

public enum TypeEnum{
    [EnumMember(Value ="aerobic"),Description("breathtaking")]
    aerobic,
    [EnumMember(Value = "strenght"), Description("")]
    strenght,
    [EnumMember(Value = "flexibility"), Description("")]
    flexibility,
    [EnumMember(Value = "mobility"), Description("")]
    mobility,
    [EnumMember(Value = "balance"), Description("")]
    balance
};

namespace Asystent_Treningowy.Models
{
    [Table ("Excercise")]
    public class Excercise
    {
        [Key]
        public int IdExcercise { get; set; }
        [Required, RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }
        [Required, RegularExpression("\\d+(\\.\\d{1})?")]
        public double BurnedKcal { get; set; }
        [Required, RegularExpression("\\d+(\\.\\d{2})?")]
        public int Time { get; set; }
        [Required]
        public TypeEnum Type { get; set; }
        public List<ExerciseMuscle> ExerciseMuscle { get; set; }
        public List<TrainingExcercise> TrainingExcercises { get; set; }
    }
}
