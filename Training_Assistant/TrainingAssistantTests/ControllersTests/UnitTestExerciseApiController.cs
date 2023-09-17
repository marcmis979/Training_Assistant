using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories.Implementation;
using TrainingAssistantBLL.BusinessLogic;
using TrainingAssistantBOL.Controllers;
using TrainingAssistantWebAPI.Controllers;

namespace TrainingAssistantTests.ControllersTests
{
    public class UnitTestExerciseApiController
    {
        [Fact]
        public void TestBurnedPerHour()
        {
            Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            mockExerciseBs
                .Setup(e => e.burnedPerHour(1))
                .Returns(12000);

            ExerciseApiController exerciseApiController = new ExerciseApiController(mockExerciseBs.Object);

            Assert.Equal(12000.0, exerciseApiController.burnedPerHour(1));

        }
        [Fact]
        public void TestGetExercises()
        {
            Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            List<Exercise> expectedExercises = new List<Exercise>
            {
                new Exercise { Id = 1, Name = "Exercise1" },
                new Exercise { Id = 2, Name = "Exercise2" },
            };
            mockExerciseBs
                .Setup(e => e.GetExercises())
                .Returns(expectedExercises);

            ExerciseApiController exerciseApiController = new ExerciseApiController(mockExerciseBs.Object);

            List<Exercise> actualExercises = exerciseApiController.getExercises();

            Assert.Equal(expectedExercises, actualExercises);
        }

        [Fact]
        public void TestGetExerciseById()
        {
            Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            Exercise expectedExercise = new Exercise { Id = 1, Name = "Exercise1" };
            mockExerciseBs
                .Setup(e => e.GetExerciseById(1))
                .Returns(expectedExercise);

            ExerciseApiController exerciseApiController = new ExerciseApiController(mockExerciseBs.Object);

            Exercise actualExercise = exerciseApiController.getExercise(1);
           
            Assert.Equal(expectedExercise, actualExercise);
        }

        [Fact]
        public void TestInsertExercise()
        {
            Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            var exerciseToInsert = new Exercise { Id = 1, Name = "Exercise1" };
            mockExerciseBs
                .Setup(e => e.InsertExercise(exerciseToInsert))
                .Verifiable();

            ExerciseApiController exerciseApiController = new ExerciseApiController(mockExerciseBs.Object);

            exerciseApiController.addExercise(exerciseToInsert);

            mockExerciseBs.Verify(e => e.InsertExercise(exerciseToInsert), Times.Once);
        }

        [Fact]
        public void TestUpdateExercise()
        {
            Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            var exerciseToUpdate = new Exercise { Id = 1, Name = "Exercise1" };
            mockExerciseBs
                .Setup(e => e.UpdateExercise(exerciseToUpdate))
                .Verifiable();
            mockExerciseBs
                .Setup(e => e.GetExerciseById(1))
                .Returns(new Exercise { Id = 1, Name = "Exercise1" });

            ExerciseApiController exerciseApiController = new ExerciseApiController(mockExerciseBs.Object);

            exerciseApiController.UpdateExercise(1, exerciseToUpdate);

            mockExerciseBs.Verify(e => e.UpdateExercise(exerciseToUpdate), Times.Once);
        }

        [Fact]
        public void TestDeleteExercise()
        {
            Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            mockExerciseBs
                .Setup(e => e.DeleteExercise(1))
                .Verifiable();
            mockExerciseBs
                .Setup(e => e.GetExerciseById(1))
                .Returns(new Exercise { Id = 1, Name = "Exercise1" });

            ExerciseApiController exerciseApiController = new ExerciseApiController(mockExerciseBs.Object);

            exerciseApiController.DeleteExercise(1);

            mockExerciseBs.Verify(e => e.DeleteExercise(1), Times.Once);
        }

        [Fact]
        public void TestAddMusclePartToExercise()
        {
            Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            var exerciseToUpdate = new Exercise { Id = 1, Name = "Exercise1" };
            mockExerciseBs
                .Setup(e => e.AddMusclePartToExercise(exerciseToUpdate, 2))
                .Verifiable();
            mockExerciseBs
                .Setup(e => e.GetExerciseById(1))
                .Returns(new Exercise { Id = 1, Name = "Exercise1" });

            ExerciseApiController exerciseApiController = new ExerciseApiController(mockExerciseBs.Object);

            exerciseApiController.AddMusclePartToExercise(exerciseToUpdate, 1, 2);

            mockExerciseBs.Verify(e => e.AddMusclePartToExercise(exerciseToUpdate, 2), Times.Once);
        }

        [Fact]
        public void TestRemoveMusclePartFromExercise()
        {
            Mock<IExerciseBs> mockExerciseBs = new Mock<IExerciseBs>();
            var exerciseToUpdate = new Exercise { Id = 1, Name = "Exercise1" };
            mockExerciseBs
                .Setup(e => e.RemoveMusclePartFromExercise(exerciseToUpdate, 2))
                .Verifiable();
            mockExerciseBs
                .Setup(e => e.GetExerciseById(1))
                .Returns(new Exercise { Id = 1, Name = "Exercise1" });

            ExerciseApiController exerciseApiController = new ExerciseApiController(mockExerciseBs.Object);

            exerciseApiController.RemoveMusclePartFromExercise(exerciseToUpdate, 1, 2);

            mockExerciseBs.Verify(e => e.RemoveMusclePartFromExercise(exerciseToUpdate, 2), Times.Once);
        }
    }
}
