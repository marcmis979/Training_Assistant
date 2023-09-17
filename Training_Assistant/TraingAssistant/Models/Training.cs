using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraingAssistantDAL.Models
{
    public class Training
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public int Days { get; set; }
        public ICollection<Exercise>? Exercises { get; set; } = new List<Exercise>();
        public TrainingPlan? TrainingPlan { get; set; } 
        public int? TrainingPlanId { get; set; }
    }
}
