using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

public enum SexEnum
{
    [EnumMember(Value = "Man")]
    Man,
    [EnumMember(Value = "Woman")]
    Woman
}

namespace Asystent_Treningowy.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required, RegularExpression("[a-zA-Z]+")]
        public string Name { get; set; }
        [Required, RegularExpression("[a-zA-Z]+")]
        public string Surname { get; set; }
        [Required,]
        public SexEnum Sex { get; set; }
        [Required,RegularExpression("^((?:20|19)(?:\\d{2})|(?:(?:\\d{2})(?:0[0-9]|1[0-2])))$")]
        public int Age { get; set; }
        [Required,Range(1,250)]
        public int Height { get; set; }
        [Required, Range(1,700)]
        public double Weight { get; set; }
        [Required, Range(1, 600)]
        public double TargetWeight { get; set; }
        [Required, Range(0.1,10)]
        public double Tempo { get; set; }
        [Required,DataType(DataType.Password),RegularExpression("^(?=.\\d)(?=.[^\\w\\d\\s])(.{8,})$")]
        public string Password { get; set; }
        [Required,EmailAddress]
        public string Mail { get; set; }
        public virtual TrainingPlan TrainingPlan { get; set; }
    }
}
