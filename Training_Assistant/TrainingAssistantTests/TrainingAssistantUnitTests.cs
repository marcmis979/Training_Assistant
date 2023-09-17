using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;
using TraingAssistantDAL.Repositories.Implementation;
using TraingAssistantDAL.Repositories.Repositories;
using TrainingAssistantBLL.BusinessLogic;
using TrainingAssistantTests.FakeRepos;

namespace TrainingAssistantTests
{
    public class TrainingAssistantUnitTests
    {
        

        [Fact]
        public void GetTrainingsTest()
        {
            var trainings = new List<Training> { new Training(), new Training() };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.TrainingRepository.GetTrainings()).Returns(trainings);

            var trainingBs = new TrainingBs(unitOfWork.Object);
            var getTrainings = trainingBs.GetTrainings();
            Assert.Equal(trainings, getTrainings);
        }

        [Fact]
        public void GetTrainingByIdTest()
        {
            var training = new Training { Id = 1 };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.TrainingRepository.GetTrainingById(1)).Returns(training);

            var trainingBs = new TrainingBs(unitOfWork.Object);
            var getTraining = trainingBs.GetTrainingById(1);
            Assert.Equal(training, getTraining);
        }

        [Fact]
        public void InsertTrainingTest()
        {
            var training = new Training();

            var unitOfWork = new Mock<IUnitOfWork>();
            var trainingRepository = new Mock<ITrainingRepository>();
            unitOfWork.Setup(u => u.TrainingRepository).Returns(trainingRepository.Object);

            var trainingBs = new TrainingBs(unitOfWork.Object);
            trainingBs.InsertTraining(training);
            trainingRepository.Verify(r => r.InsertTraining(training), Times.Once);
        }

        [Fact]
        public void UpdateTrainingtTest()
        {
            var training = new Training { Id = 1 };

            var unitOfWork = new Mock<IUnitOfWork>();
            var trainingRepository = new Mock<ITrainingRepository>();
            unitOfWork.Setup(u => u.TrainingRepository).Returns(trainingRepository.Object);

            var trainingBs = new TrainingBs(unitOfWork.Object);
            trainingBs.UpdateTraining(training);
            trainingRepository.Verify(r => r.UpdateTraining(training), Times.Once);
        }

        [Fact]
        public void DeleteTrainingTest()
        {
            var training = 1;

            var unitOfWork = new Mock<IUnitOfWork>();
            var trainingRepository = new Mock<ITrainingRepository>();
            unitOfWork.Setup(u => u.TrainingRepository).Returns(trainingRepository.Object);

            var trainingBs = new TrainingBs(unitOfWork.Object);
            trainingBs.DeleteTraining(training);
            trainingRepository.Verify(r => r.DeleteTraining(training), Times.Once);
        }

        [Fact]
        public void GetExercisesTest()
        {
            var exercises = new List<Exercise> { new Exercise(), new Exercise() };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.ExerciseRepository.GetExercises()).Returns(exercises);

            var exerciseBs = new ExerciseBs(unitOfWork.Object);
            var getExercises = exerciseBs.GetExercises();
            Assert.Equal(exercises, getExercises);
        }

        [Fact]
        public void GetExerciseByIdTest()
        {
            var exercise = new Exercise { Id = 1 };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.ExerciseRepository.GetExerciseById(1)).Returns(exercise);

            var exerciseBs = new ExerciseBs(unitOfWork.Object);
            var getExercise = exerciseBs.GetExerciseById(1);
            Assert.Equal(exercise, getExercise);
        }

        [Fact]
        public void InsertExerciseTest()
        {
            var exercise = new Exercise();

            var unitOfWork = new Mock<IUnitOfWork>();
            var exerciseRepository = new Mock<IExerciseRepository>();
            unitOfWork.Setup(u => u.ExerciseRepository).Returns(exerciseRepository.Object);

            var exerciseBs = new ExerciseBs(unitOfWork.Object);
            exerciseBs.InsertExercise(exercise);
            exerciseRepository.Verify(r => r.InsertExercise(exercise), Times.Once);
        }

        [Fact]
        public void UpdateExerciseTest()
        {
            var exercise = new Exercise { Id = 1 };

            var unitOfWork = new Mock<IUnitOfWork>();
            var exerciseRepository = new Mock<IExerciseRepository>();
            unitOfWork.Setup(u => u.ExerciseRepository).Returns(exerciseRepository.Object);

            var exerciseBs = new ExerciseBs(unitOfWork.Object);
            exerciseBs.UpdateExercise(exercise);
            exerciseRepository.Verify(r => r.UpdateExercise(exercise), Times.Once);
        }

        [Fact]
        public void DeleteExerciseTest()
        {
            var exercise = 1;

            var unitOfWork = new Mock<IUnitOfWork>();
            var exerciseRepository = new Mock<IExerciseRepository>();
            unitOfWork.Setup(u => u.ExerciseRepository).Returns(exerciseRepository.Object);

            var exerciseBs = new ExerciseBs(unitOfWork.Object);
            exerciseBs.DeleteExercise(exercise);
            exerciseRepository.Verify(r => r.DeleteExercise(exercise), Times.Once);
        }

        [Fact]
        public void BurnedPerHourTest()
        {
            var exerciseId = 1;
            var exercise = new Exercise { Id = exerciseId, BurnedKcal = 10, Time = 60 };

            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(u => u.ExerciseRepository.GetExerciseById(exerciseId)).Returns(exercise);

            var exerciseBs = new ExerciseBs(unitOfWork.Object);
            var burnedPerHour = exerciseBs.burnedPerHour(exerciseId);
            Assert.Equal(600, burnedPerHour);
        }


    }
}
