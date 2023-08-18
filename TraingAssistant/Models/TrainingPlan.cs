using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraingAssistantDAL.Models
{
    public class TrainingPlan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TrainingPlanTraing>? TrainingPlanTraings { get; set; }
        public User? User { get; set; }

        public int UserId  { get; set; }
    }
}
