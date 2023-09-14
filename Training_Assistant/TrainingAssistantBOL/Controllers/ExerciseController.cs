using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantBOL.Controllers
{
    public class ExerciseController : Controller
    {
        public readonly IExerciseBs exercise;
        public ExerciseController(IExerciseBs exercise) 
        {
            this.exercise = exercise;
        }
        public ActionResult GetExercise()
        {
            var exercises = exercise.GetExercises();
            return View(exercises);
        }

        public ActionResult GetExerciseById(int id)
        {
            var exerciseDetails = exercise.GetExerciseById(id);
            if (exerciseDetails == null)
            {
                return NotFound();
            }
            return View(exerciseDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddExercise(Exercise exerciseToCreate)
        {
            if (ModelState.IsValid)
            {
                exercise.InsertExercise(exerciseToCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(exerciseToCreate);
        }

        public ActionResult UpdateExercise(int id)
        {
            var exerciseToEdit = exercise.GetExerciseById(id);
            if (exerciseToEdit == null)
            {
                return NotFound();
            }
            return View(exerciseToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateExercise(int id, Exercise updatedExercise)
        {
            if (id != updatedExercise.Id)
            {
                return BadRequest("Invalid exercise data");
            }

            if (ModelState.IsValid)
            {
                exercise.UpdateExercise(updatedExercise);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedExercise);
        }
        
        public IActionResult burnedPerHour(int id)
        {
            ViewBag.KcalPerHour = exercise.burnedPerHour(id);
            return View();
        }

        public ActionResult DeleteExercise(int id)
        {
            var exerciseToDelete = exercise.GetExerciseById(id);
            if (exerciseToDelete == null)
            {
                return NotFound();
            }
            return View(exerciseToDelete);
        }

    }
}
