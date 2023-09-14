using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TraingAssistantDAL.Models;
using TrainingAssistantBLL.BusinessLogic;

namespace TrainingAssistantBOL.Controllers
{
    public class TrainingPlanController : Controller
    {
        public readonly ITrainingPlanBs trainingPlan;
        public TrainingPlanController(ITrainingPlanBs trainingPlan)
        {
            this.trainingPlan = trainingPlan;
        }
        public IActionResult GetTrainingPlans()
        {
            var trainingPlans = trainingPlan.GetTrainingPlans();
            return View(trainingPlans);
        }

        public IActionResult GetTrainingPlanById(int id)
        {
            var trainingPlanDetails = trainingPlan.GetTrainingPlanById(id);
            if (trainingPlanDetails == null)
            {
                return NotFound();
            }
            return View(trainingPlanDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddTrainingPlan(TrainingPlan trainingPlanToCreate)
        {
            if (ModelState.IsValid)
            {
                trainingPlan.InsertTrainingPlan(trainingPlanToCreate);
                return RedirectToAction(nameof(Index));
            }
            return View(trainingPlanToCreate);
        }

        public IActionResult UpdateTrainingPlan(int id)
        {
            var trainingPlanToEdit = trainingPlan.GetTrainingPlanById(id);
            if (trainingPlanToEdit == null)
            {
                return NotFound();
            }
            return View(trainingPlanToEdit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateTrainingPlan(int id, TrainingPlan updatedTrainingPlan)
        {
            if (id != updatedTrainingPlan.Id)
            {
                return BadRequest("Invalid training plan data");
            }

            if (ModelState.IsValid)
            {
                trainingPlan.UpdateTrainingPlan(updatedTrainingPlan);
                return RedirectToAction(nameof(Index));
            }
            return View(updatedTrainingPlan);
        }

        public IActionResult DeleteTrainingPlan(int id)
        {
            var trainingPlanToDelete = trainingPlan.GetTrainingPlanById(id);
            if (trainingPlanToDelete == null)
            {
                return NotFound();
            }
            return View(trainingPlanToDelete);
        }
    }
}
