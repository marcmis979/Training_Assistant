using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;
using TrainingAssistantWebAPI.Controllers;

namespace TrainingAssistantTests.ControllersTests
{
    public class UnitTestTrainingAPIController
    {
        [Fact]
        public void TestSummaryCalories()
        {
            Mock<ITrainingBs> mockTrainingBs = new Mock<ITrainingBs>();
            mockTrainingBs
                .Setup(t => t.summaryCalories(1))
                .Returns(2000);

            TrainingApiController trainingApiController = new TrainingApiController(mockTrainingBs.Object);

            Assert.Equal(2000.0, trainingApiController.summaryCalories(1));
        }

        [Fact]
        public void TestGetTrainings()
        {
            Mock<ITrainingBs> mockTrainingBs = new Mock<ITrainingBs>();
            List<Training> expectedTrainings = new List<Training>
            {
                new Training { Id = 1, Name = "Training1" },
                new Training { Id = 2, Name = "Training2" },
            };
            mockTrainingBs
                .Setup(t => t.GetTrainings())
                .Returns(expectedTrainings);

            TrainingApiController trainingApiController = new TrainingApiController(mockTrainingBs.Object);

            List<Training> actualTrainings = trainingApiController.GetTrainings();

            Assert.Equal(expectedTrainings, actualTrainings);
        }

        [Fact]
        public void TestGetTrainingById()
        {
            Mock<ITrainingBs> mockTrainingBs = new Mock<ITrainingBs>();
            Training expectedTraining = new Training { Id = 1, Name = "Training1" };
            mockTrainingBs
                .Setup(t => t.GetTrainingById(1))
                .Returns(expectedTraining);

            TrainingApiController trainingApiController = new TrainingApiController(mockTrainingBs.Object);

            Training actualTraining = trainingApiController.getTraining(1);

            Assert.Equal(expectedTraining, actualTraining);
        }

        [Fact]
        public void TestInsertTraining()
        {
            Mock<ITrainingBs> mockTrainingBs = new Mock<ITrainingBs>();
            var trainingToInsert = new Training { Id = 1, Name = "Training1" };
            mockTrainingBs
                .Setup(t => t.InsertTraining(trainingToInsert))
                .Verifiable();

            TrainingApiController trainingApiController = new TrainingApiController(mockTrainingBs.Object);

            trainingApiController.AddTraining(trainingToInsert);

            mockTrainingBs.Verify(t => t.InsertTraining(trainingToInsert), Times.Once);
        }

        [Fact]
        public void TestUpdateTraining()
        {
            Mock<ITrainingBs> mockTrainingBs = new Mock<ITrainingBs>();
            var trainingToUpdate = new Training { Id = 1, Name = "Training1" };
            mockTrainingBs
                .Setup(t => t.UpdateTraining(trainingToUpdate))
                .Verifiable();
            mockTrainingBs
                .Setup(t => t.GetTrainingById(1))
                .Returns(new Training { Id = 1, Name = "Training1" });

            TrainingApiController trainingApiController = new TrainingApiController(mockTrainingBs.Object);

            trainingApiController.UpdateTraining(1, trainingToUpdate);

            mockTrainingBs.Verify(t => t.UpdateTraining(trainingToUpdate), Times.Once);
        }

        [Fact]
        public void TestDeleteTraining()
        {
            Mock<ITrainingBs> mockTrainingBs = new Mock<ITrainingBs>();
            mockTrainingBs
                .Setup(t => t.DeleteTraining(1))
                .Verifiable();
            mockTrainingBs
                .Setup(t => t.GetTrainingById(1))
                .Returns(new Training { Id = 1, Name = "Training1" });

            TrainingApiController trainingApiController = new TrainingApiController(mockTrainingBs.Object);

            trainingApiController.DeleteTraining(1);

            mockTrainingBs.Verify(t => t.DeleteTraining(1), Times.Once);
        }
    }
}
