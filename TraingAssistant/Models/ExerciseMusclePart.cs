using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraingAssistantDAL.Models
{
    public class ExerciseMusclePart
    {
        public int ExercisesId { get; set; }
        public int MusclePartsId { get; set; }
        public Exercise Exercise { get; set; }
        public MusclePart MusclePart { get; set; }
    }
}
