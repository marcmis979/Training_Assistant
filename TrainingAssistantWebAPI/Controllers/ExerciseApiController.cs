using Microsoft.AspNetCore.Mvc;
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
    }
}
