using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;
using TrainingAssistantBOL.Controllers;

namespace TrainingAssistantTests.ControllersTests
{
    public class UnitTestTrainingController
    {

        [Fact]
        public void TestGetTrainings()
        {
            var mockTrainingBs = new Mock<ITrainingBs>();
            var trainings = new List<Training> { new Training { Id = 1, Name = "Training1" } };
            mockTrainingBs.Setup(t => t.GetTrainings()).Returns(trainings);

            var trainingController = new TrainingController(mockTrainingBs.Object);

            var result = trainingController.GetTrainings() as ViewResult;

            Assert.NotNull(result);
            var model = result.Model as List<Training>;
            Assert.NotNull(model);
            Assert.Single(model);
        }

        [Fact]
        public void TestAddTraining()
        {
            var mockTrainingBs = new Mock<ITrainingBs>();
            var trainingToCreate = new Training { Id = 1, Name = "Training1" };

            var trainingController = new TrainingController(mockTrainingBs.Object);

            var result = trainingController.AddTraining(trainingToCreate) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestUpdateTraining()
        {
            var mockTrainingBs = new Mock<ITrainingBs>();
            var trainingToUpdate = new Training { Id = 1, Name = "Training1" };

            var trainingController = new TrainingController(mockTrainingBs.Object);

            var result = trainingController.UpdateTraining(1, trainingToUpdate) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestDeleteTraining()
        {
            var mockTrainingBs = new Mock<ITrainingBs>();
            var trainingToDelete = new Training { Id = 1, Name = "Training1" };

            mockTrainingBs.Setup(t => t.GetTrainingById(1)).Returns(trainingToDelete);

            var trainingController = new TrainingController(mockTrainingBs.Object);

            var result = trainingController.DeleteTraining(1) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<Training>(result.Model);
            var model = result.Model as Training;
            Assert.Equal(trainingToDelete, model);
        }
    }
}
