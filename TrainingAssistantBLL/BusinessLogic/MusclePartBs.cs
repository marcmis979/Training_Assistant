using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;

namespace TrainingAssistantBLL.BusinessLogic
{
    public class MusclePartBs : IMusclePartBs
    {
        private IUnitOfWork unitOfWork;

        public MusclePartBs(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IEnumerable<MusclePart> GetMuscleParts()
        {
            return unitOfWork.MusclePartRepository.GetMuscleParts();
        }

        public MusclePart GetMusclePartById(int id)
        {
            return unitOfWork.MusclePartRepository.GetMusclePartById(id);
        }

        public void InsertMusclePart(MusclePart musclePart)
        {
            unitOfWork.MusclePartRepository.InsertMusclePart(musclePart);
        }

        public void UpdateMusclePart(MusclePart musclePart)
        {
            unitOfWork.MusclePartRepository.UpdateMusclePart(musclePart);
        }

        public void DeleteMusclePart(int id)
        {
            unitOfWork.MusclePartRepository.DeleteMusclePart(id);
        }
    }
}
