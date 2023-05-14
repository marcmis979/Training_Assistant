using Microsoft.AspNetCore.Mvc;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingApiController : Controller
    {
        public readonly ITrainingBs training;
        public TrainingApiController(ITrainingBs training)
        {
            this.training = training;
        }
        [HttpGet("summary/{id}")]
        public double summaryCalories(int id)
        {
            return training.summaryCalories(id);
        }
    }
}
