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
    }
}
