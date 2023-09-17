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
        [HttpGet("getTraining/{id}")]
        public Training getTraining(int id)
        {
            return training.GetTrainingById(id);
        }
        [HttpGet("getTrainings")]
        public List<Training> GetTrainings()
        {
            return training.GetTrainings();
        }
        [HttpPost("addTraining")]
        public IActionResult AddTraining([FromBody] Training tr)
        {
            if (tr == null)
            {
                return BadRequest("Invalid training data");
            }

            training.InsertTraining(tr);

            return CreatedAtAction("GetTraining", new { id = tr.Id }, tr);
        }
        [HttpPut("updateTraining/{id}")]
        public IActionResult UpdateTraining(int id, [FromBody] Training updatedTraining)
        {
            if (updatedTraining == null || updatedTraining.Id != id)
            {
                return BadRequest("Invalid training data");
            }

            var existingTraining = training.GetTrainingById(id);
            if (existingTraining == null)
            {
                return NotFound();
            }

            training.UpdateTraining(updatedTraining);

            return NoContent();
        }
        [HttpDelete("deleteTraining/{id}")]
        public IActionResult DeleteTraining(int id)
        {
            var existingTraining = training.GetTrainingById(id);
            if (existingTraining == null)
            {
                return NotFound();
            }

            training.DeleteTraining(id);

            return NoContent();
        }

        [HttpPut("addExerciseToTraining/{id}/{exerciseId}")]
        public IActionResult AddExerciseToTraining(Training updatedTraining, int id, int exerciseId)
        {
            if (updatedTraining == null || updatedTraining.Id != id)
            {
                return BadRequest("Invalid exercise data");
            }

            var existingExercise = training.GetTrainingById(id);
            if (existingExercise == null)
            {
                return NotFound();
            }

            training.AddExerciseToTraining(updatedTraining, exerciseId);

            return NoContent();
        }

        [HttpPut("removeExerciseFromTraining/{id}/{exerciseId}")]
        public IActionResult RemoveExerciseFromTraining(Training updatedTraining, int id, int exerciseId)
        {
            if (updatedTraining == null || updatedTraining.Id != id)
            {
                return BadRequest("Invalid exercise data");
            }

            var existingExercise = training.GetTrainingById(id);
            if (existingExercise == null)
            {
                return NotFound();
            }

            training.RemoveExerciseFromTraining(updatedTraining, exerciseId);

            return NoContent();
        }

    }
}
