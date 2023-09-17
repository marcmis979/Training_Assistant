using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantBOL.Controllers
{
    public class TrainingController : Controller
    {
        public readonly ITrainingBs training;
        public TrainingController(ITrainingBs training)
        {
            this.training = training;
        }

        public ActionResult GetTrainings()
        {
            var trainings = training.GetTrainings();
            return View(trainings);
        }

        public ActionResult GetTrainingById(int id)
        {
            var trainingDetails = training.GetTrainingById(id);
            if (trainingDetails == null)
            {
                return NotFound();
            }
            return View(trainingDetails);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTraining(Training trainingToCreate)
        {
            if (ModelState.IsValid)
            {
                training.InsertTraining(trainingToCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(trainingToCreate);
        }

        public ActionResult UpdateTraining(int id)
        {
            var trainingToEdit = training.GetTrainingById(id);
            if (trainingToEdit == null)
            {
                return NotFound();
            }
            return View(trainingToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTraining(int id, Training updatedTraining)
        {
            if (id != updatedTraining.Id)
            {
                return BadRequest("Invalid training data");
            }

            if (ModelState.IsValid)
            {
                training.UpdateTraining(updatedTraining);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedTraining);
        }

        public ActionResult DeleteTraining(int id)
        {
            var trainingToDelete = training.GetTrainingById(id);
            if (trainingToDelete == null)
            {
                return NotFound();
            }
            return View(trainingToDelete);
        }

    }
}
