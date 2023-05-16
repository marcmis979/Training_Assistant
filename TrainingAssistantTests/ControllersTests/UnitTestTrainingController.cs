using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingAssistantBLL.BusinessLogic;
using TrainingAssistantBOL.Controllers;

namespace TrainingAssistantTests.ControllersTests
{
    public class UnitTestTrainingController
    {
        [Fact]
        public void TestSummaryCalories()
        {
            Mock<ITrainingBs> mockTrainingBs = new Mock<ITrainingBs>();
            mockTrainingBs
                .Setup(t => t.summaryCalories(1))
                .Returns(2000);

            TrainingController trainingController = new TrainingController(mockTrainingBs.Object);
            var result = trainingController.summaryCalories(1);

            Assert.IsType<ViewResult>(result);
            var viewResult = (ViewResult)result;
            Assert.Equal(2000.0, viewResult.ViewData["SummaryCalories"]);
        }
    }
}
