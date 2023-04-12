using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // GET: ExerciseController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ExerciseController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExerciseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExerciseController/Create
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

        // GET: ExerciseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExerciseController/Edit/5
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

        // GET: ExerciseController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExerciseController/Delete/5
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
