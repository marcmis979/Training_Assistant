using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAssistantBLL.BusinessLogic;
using TrainingAssistantBOL.Controllers;
using TrainingAssistantBLL;
using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;

namespace TrainingAssistantTests.ControllersTests
{
    public class UnitTestExerciseController
    {
        [Fact]
        public void TestBurnedPerHour() { 
        Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            mockExerciseBs
                .Setup( e => e.burnedPerHour(1))
                .Returns(12000);

            ExerciseController exerciseController = new ExerciseController(mockExerciseBs.Object);
            var result = exerciseController.burnedPerHour(1);

            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;    
            Assert.Equal(12000.0, viewResult.ViewData["KcalPerHour"]);
        }

        [Fact]
        public void TestGetExercises()
        {
            var mockExerciseBs = new Mock<IExerciseBs>();
            var exercises = new List<Exercise> { new Exercise { Id = 1, Name = "Exercise1" } };
            mockExerciseBs.Setup(e => e.GetExercises()).Returns(exercises);

            var exerciseController = new ExerciseController(mockExerciseBs.Object);

            var result = exerciseController.GetExercise() as ViewResult;

            Assert.NotNull(result);
            var model = result.Model as List<Exercise>;
            Assert.NotNull(model);
            Assert.Single(model);
        }

        [Fact]
        public void TestAddExercise()
        {
            var mockExerciseBs = new Mock<IExerciseBs>();
            var exerciseToCreate = new Exercise { Id = 1, Name = "Exercise1" };

            var exerciseController = new ExerciseController(mockExerciseBs.Object);

            var result = exerciseController.AddExercise(exerciseToCreate) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestUpdateExercise()
        {
            var mockExerciseBs = new Mock<IExerciseBs>();
            var exerciseToUpdate = new Exercise { Id = 1, Name = "Exercise1" };

            var exerciseController = new ExerciseController(mockExerciseBs.Object);

            var result = exerciseController.UpdateExercise(1, exerciseToUpdate) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public void TestDelete()
        {
            var mockExerciseBs = new Mock<IExerciseBs>();
            var exerciseToDelete = new Exercise { Id = 1, Name = "Exercise1" };

            mockExerciseBs.Setup(e => e.GetExerciseById(1)).Returns(exerciseToDelete);

            var exerciseController = new ExerciseController(mockExerciseBs.Object);

            var result = exerciseController.DeleteExercise(1) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<Exercise>(result.Model);
            var model = result.Model as Exercise;
            Assert.Equal(exerciseToDelete, model);
        }
    }

    
}
