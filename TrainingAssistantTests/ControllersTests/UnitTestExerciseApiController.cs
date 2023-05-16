using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
