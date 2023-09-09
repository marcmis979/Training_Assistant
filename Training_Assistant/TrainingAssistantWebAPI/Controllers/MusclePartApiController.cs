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
        [HttpGet("getMuscleParts")]
        public List<MusclePart> GetMuscleParts()
        {
            return musclePart.GetMuscleParts();
        }
        [HttpPost("addMusclePart")]
        public IActionResult AddMusclePart([FromBody] MusclePart mp)
        {
            if (mp == null)
            {
                return BadRequest("Invalid muscle part data");
            }

            musclePart.InsertMusclePart(mp);

            return CreatedAtAction("GetMusclePart", new { id = mp.Id }, mp);
        }
        [HttpPut("updateMusclePart/{id}")]
        public IActionResult UpdateMusclePart(int id, [FromBody] MusclePart updatedMusclePart)
        {
            if (updatedMusclePart == null || updatedMusclePart.Id != id)
            {
                return BadRequest("Invalid muscle part data");
            }

            var existingMusclePart = musclePart.GetMusclePartById(id);
            if (existingMusclePart == null)
            {
                return NotFound();
            }

            musclePart.UpdateMusclePart(updatedMusclePart);

            return NoContent();
        }
        [HttpDelete("deleteMusclePart/{id}")]
        public IActionResult DeleteMusclePart(int id)
        {
            var existingMusclePart = musclePart.GetMusclePartById(id);
            if (existingMusclePart == null)
            {
                return NotFound();
            }

            musclePart.DeleteMusclePart(id);

            return NoContent();
        }
    }
}
