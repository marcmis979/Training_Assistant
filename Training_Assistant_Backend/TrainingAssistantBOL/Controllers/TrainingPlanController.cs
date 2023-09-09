using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // GET: TrainingPlanController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrainingPlanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TrainingPlanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrainingPlanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainingPlanController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TrainingPlanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TrainingPlanController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrainingPlanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
