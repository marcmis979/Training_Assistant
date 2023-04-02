using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraingAssistantDAL.Models
{
    public class TrainingPlanTraing
    {
        public int TrainingPlanId { get; set; }
        public int TrainingId { get; set; }
        public TrainingPlan TrainingPlan { get; set; }
        public Training Training { get; set; }
    }
}
