using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TrainingAssistantTests.FakeRepos
{
    public class FakeMusclePartRepo : IMusclePartRepository
    {
        private List<MusclePart> _trainings = new List<MusclePart>();
        public IEnumerable<MusclePart> GetMuscleParts()
        {
            return _trainings;
        }

        public MusclePart GetMusclePartById(int id)
        {
            return _trainings.FirstOrDefault(x => x.Id == id); ;
        }

        public void InsertMusclePart(MusclePart training)
        {
            _trainings.Add(training);
        }

        public void DeleteMusclePart(int id)
        {
            _trainings.Remove(_trainings.FirstOrDefault(x => x.Id == id));
        }

        public void UpdateMusclePart(MusclePart musclePart)
        {
            int index = musclePart.Id;

            if (_trainings.Contains(musclePart))
            {
                _trainings[index].Name = musclePart.Name;
            }
            else
            {
                _trainings.Add(musclePart);
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
