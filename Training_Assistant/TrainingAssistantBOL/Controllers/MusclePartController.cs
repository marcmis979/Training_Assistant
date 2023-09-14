using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantBOL.Controllers
{
    public class MusclePartController : Controller
    {
        public readonly IMusclePartBs musclePart;
        public MusclePartController(IMusclePartBs musclePart)
        {
            this.musclePart = musclePart;
        }
        public IActionResult GetMuscleParts()
        {
            var muscleParts = musclePart.GetMuscleParts();
            return View(muscleParts);
        }

        public IActionResult GetMusclePartById(int id)
        {
            var musclePartDetails = musclePart.GetMusclePartById(id);
            if (musclePartDetails == null)
            {
                return NotFound();
            }
            return View(musclePartDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMusclePart(MusclePart musclePartToCreate)
        {
            if (ModelState.IsValid)
            {
                musclePart.InsertMusclePart(musclePartToCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(musclePartToCreate);
        }

        public IActionResult UpdateMusclePart(int id)
        {
            var musclePartToEdit = musclePart.GetMusclePartById(id);
            if (musclePartToEdit == null)
            {
                return NotFound();
            }
            return View(musclePartToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMusclePart(int id, MusclePart updatedMusclePart)
        {
            if (id != updatedMusclePart.Id)
            {
                return BadRequest("Invalid muscle part data");
            }

            if (ModelState.IsValid)
            {
                musclePart.UpdateMusclePart(updatedMusclePart);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedMusclePart);
        }

        public IActionResult DeleteMusclePart(int id)
        {
            var musclePartToDelete = musclePart.GetMusclePartById(id);
            if (musclePartToDelete == null)
            {
                return NotFound();
            }
            return View(musclePartToDelete);
        }
    }
}
