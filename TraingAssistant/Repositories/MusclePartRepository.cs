using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories
{
    public class MusclePartRepository : IMusclePartRepository, IDisposable
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

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
