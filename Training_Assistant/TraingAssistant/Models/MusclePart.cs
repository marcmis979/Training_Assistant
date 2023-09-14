using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;


namespace TraingAssistantDAL.Models
{

    public class MusclePart
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ExerciseMusclePart>? ExercisesMuscleParts { get; set; }

        public Exercise? Exercise { get; set; }

        public int? ExerciseId { get; set; }

    }
}
