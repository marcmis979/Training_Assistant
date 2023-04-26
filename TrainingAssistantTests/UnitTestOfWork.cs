using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraingAssistantDAL;
using TraingAssistantDAL.Repositories.Repositories;
using TrainingAssistantTests.FakeRepos;

namespace TrainingAssistantTests
{
    public class UnitTestOfWork
    {
        [Fact]
        public void TestUnitOfWork() { 
            var trainingRepo = new TrainingRepoDummy();
            var exerciseRepo = new ExerciseRepoDummy();
            var trainingPlanRepo = new TrainingPlanRepoDummy();
            var musclePartRepo = new MusclePartRepoDummy();
            var userRepo = new UserRepoDummy(); 
            var unitOfWork = new UnitOfWork(userRepo, trainingPlanRepo, trainingRepo, musclePartRepo, exerciseRepo);
            Assert.Same(trainingRepo, unitOfWork.TrainingRepository);
            Assert.Same(userRepo, unitOfWork.UserRepository);
            Assert.Same(exerciseRepo, unitOfWork.ExerciseRepository);
            Assert.Same(musclePartRepo, unitOfWork.MusclePartRepository);
            Assert.Same(trainingPlanRepo, unitOfWork.TrainingPlanRepository);
        }
    }
}
