﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories
{
    public interface IMusclePartRepository
    {
        IEnumerable<MusclePart> GetMuscleParts();
        MusclePart GetMusclePartById(int id);
        void InsertMusclePart(MusclePart musclePart);
        void DeleteMusclePart(int id);
        void UpdateMusclePart(MusclePart musclePart);
    }
}