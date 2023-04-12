using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        // GET: MusclePartControllercs
        public ActionResult Index()
        {
            return View();
        }

        // GET: MusclePartControllercs/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MusclePartControllercs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MusclePartControllercs/Create
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

        // GET: MusclePartControllercs/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MusclePartControllercs/Edit/5
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

        // GET: MusclePartControllercs/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MusclePartControllercs/Delete/5
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
