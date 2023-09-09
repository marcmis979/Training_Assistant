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
        public List<TrainingExercise>? TrainingExercises { get; set; }
        public List<TrainingPlanTraing>? TrainingPlanTraings { get; set; }
    }
}
