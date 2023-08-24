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
            context.SaveChanges();
        }

        public void DeleteMusclePart(int id)
        {
            MusclePart musclePart = context.MuscleParts.Find(id);
            context.MuscleParts.Remove(musclePart);
            context.SaveChanges();
        }

        public void UpdateMusclePart(MusclePart updatedMusclePart)
        {
            var existingMusclePart = context.MuscleParts.Find(updatedMusclePart.Id);

            if (existingMusclePart != null)
            {
                existingMusclePart.Name = updatedMusclePart.Name;

                context.SaveChanges();
            }
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
