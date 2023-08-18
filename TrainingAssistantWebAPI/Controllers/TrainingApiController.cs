using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
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
        [HttpGet("getTraining/{id}")]
        public Training getTraining(int id)
        {
            return training.GetTrainingById(id);
        }
        [HttpPost("addTraining")]
        public void addTraining(Training tr)
        {
            training.InsertTraining(tr);
        }
        [HttpPut("updateTraining")]
        public void updateTraining(Training tr)
        {
            training.UpdateTraining(tr);
        }


    }
}
