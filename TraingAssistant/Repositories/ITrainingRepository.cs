using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;

namespace TraingAssistantDAL.Repositories
{
    public interface ITrainingRepository
    {
        IEnumerable<Training> GetTrainings();
        Training GetTrainingById(int id);
        void InsertTraining(Training training);
        void DeleteTraining(int id);
        void UpdateTraining(Training training);
    }
}
