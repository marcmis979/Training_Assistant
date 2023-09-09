using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExerciseApiController : Controller
    {
        public readonly IExerciseBs exercise;
        public ExerciseApiController(IExerciseBs exercise)
        {
            this.exercise = exercise;
        }
        [HttpGet("burned/{id}")]
        public double burnedPerHour(int id)
        {
            return exercise.burnedPerHour(id);
        }
        [HttpGet("getExercise/{id}")]
        public Exercise getExercise(int id)
        {
            return exercise.GetExerciseById(id);
        }
        [HttpGet("getExercises")]
        public List<Exercise> getExercises()
        {
            return exercise.GetExercises();
        }
        [HttpPost("addExercise")]
        public IActionResult addExercise([FromBody] Exercise ex)
        {
            if (ex == null)
            {
                return BadRequest("Invalid exercise data");
            }
            exercise.InsertExercise(ex);

            return CreatedAtAction("GetExercise", new { id = ex.Id },ex);
        }
        [HttpPut("updateExercise/{id}")]
        public IActionResult UpdateExercise(int id, [FromBody] Exercise updatedExercise)
        {
            if (updatedExercise == null || updatedExercise.Id != id)
            {
                return BadRequest("Invalid exercise data");
            }

            var existingExercise = exercise.GetExerciseById(id);
            if (existingExercise == null)
            {
                return NotFound();
            }

            exercise.UpdateExercise(updatedExercise);

            return NoContent();
        }
        [HttpDelete("deleteExercise/{id}")]
        public IActionResult DeleteExercise(int id)
        {
            var existingExercise = exercise.GetExerciseById(id);
            if (existingExercise == null)
            {
                return NotFound();
            }

            exercise.DeleteExercise(id);

            return NoContent();
        }

    }
}
