using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
