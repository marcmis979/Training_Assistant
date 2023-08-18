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
        [HttpPost("addExercise")]
        public void addExercise(Exercise ex)
        {
            exercise.InsertExercise(ex);
        }
        [HttpPut("updateExercise")]
        public void updateExercise(Exercise ex)
        {
            exercise.UpdateExercise(ex);
        }

    }
}
