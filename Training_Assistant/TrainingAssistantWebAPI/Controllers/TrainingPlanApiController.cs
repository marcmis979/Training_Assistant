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
        [HttpGet("getTrainingPlan/{id}")]
        public TrainingPlan getTrainingPlan(int id)
        {
            return trainingPlan.GetTrainingPlanById(id);
        }
        [HttpGet("getTrainingPlans")]
        public List<TrainingPlan> GetTrainingPlans()
        {
            return trainingPlan.GetTrainingPlans();
        }
        [HttpPost("addTrainingPlan")]
        public IActionResult AddTrainingPlan([FromBody] TrainingPlan tr)
        {
            if (tr == null)
            {
                return BadRequest("Invalid training plan data");
            }

            trainingPlan.InsertTrainingPlan(tr);

            return CreatedAtAction("GetTrainingPlan", new { id = tr.Id }, tr);
        }
        [HttpPut("updateTrainingPlan/{id}")]
        public IActionResult UpdateTrainingPlan(int id, [FromBody] TrainingPlan updatedTrainingPlan)
        {
            if (updatedTrainingPlan == null || updatedTrainingPlan.Id != id)
            {
                return BadRequest("Invalid training plan data");
            }

            var existingTrainingPlan = trainingPlan.GetTrainingPlanById(id);
            if (existingTrainingPlan == null)
            {
                return NotFound();
            }

            trainingPlan.UpdateTrainingPlan(updatedTrainingPlan);

            return NoContent();
        }
        [HttpDelete("deleteTrainingPlan/{id}")]
        public IActionResult DeleteTrainingPlan(int id)
        {
            var existingTrainingPlan = trainingPlan.GetTrainingPlanById(id);
            if (existingTrainingPlan == null)
            {
                return NotFound();
            }

            trainingPlan.DeleteTrainingPlan(id);

            return NoContent();
        }
    }
}
