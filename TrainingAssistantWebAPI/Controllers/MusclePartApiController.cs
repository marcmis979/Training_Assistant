using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MusclePartApiController : Controller
    {
        public readonly IMusclePartBs musclePart;
        public MusclePartApiController(IMusclePartBs musclePart)
        {
            this.musclePart = musclePart;
        }
        [HttpGet("getMusclePart/{id}")]
        public MusclePart getMusclePart(int id)
        {
            return musclePart.GetMusclePartById(id);
        }
        [HttpPost("addMusclePart")]
        public void addExercise(MusclePart mp)
        {
            musclePart.InsertMusclePart(mp);
        }
        [HttpPut("updateMusclePart")]
        public void updateMusclePart(MusclePart mp)
        {
            musclePart.UpdateMusclePart(mp);
        }
    }
}
