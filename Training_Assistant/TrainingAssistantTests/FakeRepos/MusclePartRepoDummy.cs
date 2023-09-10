using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantTests.FakeRepos
{
    internal class MusclePartRepoDummy : IMusclePartRepository
    {
        public void DeleteMusclePart(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public MusclePart GetMusclePartById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MusclePart> GetMuscleParts()
        {
            throw new NotImplementedException();
        }

        public void InsertMusclePart(MusclePart musclePart)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateMusclePart(MusclePart musclePart)
        {
            throw new NotImplementedException();
        }

        List<MusclePart> IMusclePartRepository.GetMuscleParts()
        {
            throw new NotImplementedException();
        }
    }
}
