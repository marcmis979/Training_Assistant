using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainingPlanApiController : Controller
    {
        public readonly ITrainingPlanBs trainingPlan;
        public TrainingPlanApiController(ITrainingPlanBs trainingPlan)
        {
            this.trainingPlan = trainingPlan;
        }
        [HttpGet("getTraining/{id}")]
        public TrainingPlan getTrainingPlan(int id)
        {
            return trainingPlan.GetTrainingPlanById(id);
        }
        [HttpPost("addTraining")]
        public void addTraining(TrainingPlan tr)
        {
            trainingPlan.InsertTrainingPlan(tr);
        }
        [HttpPut("updateTraining")]
        public void updateTraining(TrainingPlan tr)
        {
            trainingPlan.UpdateTrainingPlan(tr);
        }
    }
}
