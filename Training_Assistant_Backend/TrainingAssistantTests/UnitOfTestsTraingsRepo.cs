using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Repositories.Implementation;
using TraingAssistantDAL.Repositories.Repositories;
using TraingAssistantDAL.Repositories;
using TraingAssistantDAL.DataAccess;
using TraingAssistantDAL.Models;

namespace TrainingAssistantTests
{

    public class UnitOfTestsTraingsRepo
    {
        [Fact]
        public void TestGetTraing() {
            var options = new DbContextOptionsBuilder<TrainingAssistantContext>()
    .UseInMemoryDatabase("Testowa")
    .Options;
            var trainingContext = new TrainingAssistantContext(options);
            TrainingRepository trainingRepository = new TrainingRepository(trainingContext);
            Assert.Empty(trainingRepository.GetTrainings());
            trainingRepository.InsertTraining(new TraingAssistantDAL.Models.Training {Id=1, Name="Cardio", Days=3 });
            trainingRepository.Save();
            Assert.Equal(1, trainingRepository.GetTrainings().Count());
        }
    }
}
