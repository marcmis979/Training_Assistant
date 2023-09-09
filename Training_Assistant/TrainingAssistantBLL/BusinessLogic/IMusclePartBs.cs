using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TrainingAssistantBLL.BusinessLogic
{
    public interface IMusclePartBs
    {
        public IEnumerable<MusclePart> GetMuscleParts();
        public MusclePart GetMusclePartById(int id);
        public void InsertMusclePart(MusclePart musclePart);
        public void UpdateMusclePart(MusclePart musclePart);
        public void DeleteMusclePart(int id);
    }
}
