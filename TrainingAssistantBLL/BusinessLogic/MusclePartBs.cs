using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantBLL.BusinessLogic
{
    internal class MusclePartBs : IMusclePartBs
    {
        private MusclePartRepository musclePartRepository;

        public MusclePartBs(MusclePartRepository musclePartRepository)
        {
            this.musclePartRepository = musclePartRepository;
        }
        public IEnumerable<MusclePart> GetMuscleParts()
        {
            return musclePartRepository.GetMuscleParts();
        }

        public MusclePart GetMusclePartById(int id)
        {
            return musclePartRepository.GetMusclePartById(id);
        }

        public void InsertMusclePart(MusclePart musclePart)
        {
            musclePartRepository.InsertMusclePart(musclePart);
        }

        public void UpdateMusclePart(MusclePart musclePart)
        {
            musclePartRepository.UpdateMusclePart(musclePart);
        }

        public void DeleteMusclePart(int id)
        {
            musclePartRepository.DeleteMusclePart(id);
        }
    }
}
