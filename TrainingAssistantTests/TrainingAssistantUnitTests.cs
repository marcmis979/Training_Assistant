using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL.Models;
using TraingAssistantDAL.Repositories;
using TrainingAssistantBLL.BusinessLogic;
using TrainingAssistantTests.FakeRepos;

namespace TrainingAssistantTests
{
    public class TrainingAssistantUnitTests
    {
        [Fact]
        public void SummaryCaloriesTest()
        {
            var exercise1 = new Exercise { Id = 1, BurnedKcal = 100 };
            var exercise2 = new Exercise { Id = 2, BurnedKcal = 150 };
            var trainingExercises = new List<TrainingExercise> { new TrainingExercise { Exercise = exercise1 }, new TrainingExercise { Exercise = exercise2 } };
            var training1 = new Training {Id = 1, TrainingExercises = trainingExercises };

            var trainingRepo = new FakeTrainingRepo();
            var trainingPlanRepo = new FakeTrainingPlanRepo();
            var musclePartRepo = new FakeMusclePartRepo();
            var userRepo = new FakeUserRepo();
            var exerciseRepo = new FakeExerciseRepo();

            exerciseRepo.InsertExercise(exercise1);
            exerciseRepo.InsertExercise(exercise2);
            trainingRepo.InsertTraining(training1);

            var unitOfWork = new UnitOfWork(userRepo, trainingPlanRepo, trainingRepo, musclePartRepo, exerciseRepo);
            var trainingBLL = new TrainingBs(unitOfWork);

            Assert.Equal(250, trainingBLL.summaryCallories(1));

        }
    }
}
