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
        // GET: TrainingController
        public ActionResult GetTrainings()
        {
            var trainings = training.GetTrainings();
            return View(trainings);
        }

        // GET: TrainingController/Details/5
        public ActionResult GetTrainingById(int id)
        {
            var trainingDetails = training.GetTrainingById(id);
            if (trainingDetails == null)
            {
                return NotFound();
            }
            return View(trainingDetails);
        }

        // GET: TrainingController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingController/Create
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

        // GET: TrainingController/Edit/5
        public ActionResult UpdateTraining(int id)
        {
            var trainingToEdit = training.GetTrainingById(id);
            if (trainingToEdit == null)
            {
                return NotFound();
            }
            return View(trainingToEdit);
        }

        // POST: TrainingController/Edit/5
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

        // GET: TrainingController/Delete/5
        public ActionResult DeleteTraining(int id)
        {
            var trainingToDelete = training.GetTrainingById(id);
            if (trainingToDelete == null)
            {
                return NotFound();
            }
            return View(trainingToDelete);
        }

        public IActionResult summaryCalories(int id)
        {
            ViewBag.SummaryCalories = training.summaryCalories(id);
            return View();
        }
    }
}
