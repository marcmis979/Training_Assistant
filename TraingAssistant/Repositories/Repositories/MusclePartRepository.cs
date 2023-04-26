using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;

namespace TraingAssistantDAL.Repositories.Repositories
{
    public class MusclePartRepository : IMusclePartRepository
    {
        private TrainingAssistantContext context;

        public MusclePartRepository(TrainingAssistantContext context)
        {
            this.context = context;
        }

        public IEnumerable<MusclePart> GetMuscleParts()
        {
            return context.MuscleParts.ToList();
        }

        public MusclePart GetMusclePartById(int id)
        {
            return context.MuscleParts.Find(id);
        }

        public void InsertMusclePart(MusclePart musclePart)
        {
            context.MuscleParts.Add(musclePart);
        }

        public void DeleteMusclePart(int id)
        {
            MusclePart musclePart = context.MuscleParts.Find(id);
            context.MuscleParts.Remove(musclePart);
        }

        public void UpdateMusclePart(MusclePart musclePart)
        {
            context.Entry(musclePart).State = EntityState.Modified;
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }

    }
}
